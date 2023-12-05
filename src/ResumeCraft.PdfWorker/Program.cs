using Autofac;
using Autofac.Extensions.DependencyInjection;
using ResumeCraft.PdfDeleteWorker;
using Serilog;

var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

try
{
    IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);

    hostBuilder.UseSerilog(
        (context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        }
    );

    hostBuilder.ConfigureAppConfiguration(
        (hostingContext, config) =>
        {
            config.SetBasePath(Directory.GetCurrentDirectory());
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }
    );

    hostBuilder.UseWindowsService();

    hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    hostBuilder.ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new WorkerModule());
    });

    hostBuilder.ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    });

    var host = hostBuilder.Build();

    logger.Information("Starting PDF Worker Service Application...");
    await host.RunAsync();
}
catch (Exception ex)
{
    logger.Fatal(ex.Message, "Failed to start PDF Worker service");
}
finally
{
    Log.CloseAndFlush();
}
