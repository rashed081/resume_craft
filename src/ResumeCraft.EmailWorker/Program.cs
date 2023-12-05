using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ResumeCraft.Application;
using ResumeCraft.Domain.Entities.Email;
using ResumeCraft.EmailWorker;
using ResumeCraft.Infrastructure;
using ResumeCraft.Persistence;
using ResumeCraft.Persistence.Database;
using Serilog;

var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

try
{
    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    var migrationAssembly = typeof(Worker).Assembly.FullName;

    IHost host = Host.CreateDefaultBuilder(args)
        .UseWindowsService()
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .UseSerilog()
        .ConfigureContainer<ContainerBuilder>(builder =>
        {
            builder.RegisterModule(new WorkerModule());
            builder.RegisterModule(new ApplicationModule());
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new PersistenceModule(connectionString, migrationAssembly));
        })
        .ConfigureServices(services =>
        {
            services.AddHostedService<Worker>();
            services.Configure<Smtp>(configuration.GetSection("Smtp"));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString, m => m.MigrationsAssembly(migrationAssembly))
            );
        })
        .Build();

    await host.RunAsync();
    logger.Information("Email service starting up.");
}
catch (Exception ex)
{
    logger.Fatal(ex, "Email service startup error.");
}
finally
{
    Log.CloseAndFlush();
}
