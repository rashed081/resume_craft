using Autofac;
using Autofac.Extensions.DependencyInjection;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ResumeCraft.Application;
using ResumeCraft.Domain.Entities.Email;
using ResumeCraft.Infrastructure;
using ResumeCraft.Persistence;
using ResumeCraft.Persistence.Database;
using ResumeCraft.Web;
using Serilog;

var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        }
    );

    var connectionString =
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    var migrationAssembly = typeof(ApplicationDbContext).Assembly.FullName!;

    // Dependency Injection
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ApplicationModule());
        containerBuilder.RegisterModule(new InfrastructureModule());
        containerBuilder.RegisterModule(new PersistenceModule(connectionString, migrationAssembly));
        containerBuilder.RegisterModule(new WebModule());
    });

    // Add services to the container.
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddIdentityUser();
    builder.Services.AddRazorPages();
    builder.Services.AddControllersWithViews();
    builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();

    builder.Services.AddHttpClient(
        "Resumecraft",
        c =>
        {
            c.BaseAddress = new Uri("https://localhost:7189/api/v1/");
        }
    );

    builder.Services.AddControllersWithViews();

    builder.Services
        .AddAuthentication()
        .AddCookie(
            CookieAuthenticationDefaults.AuthenticationScheme,
            options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                options.LogoutPath = new PathString("/Account/Logout");
                options.Cookie.Name = "AspDotNetPortal.Identity";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(12);
                options.Cookie.HttpOnly = true;
            }
        );

    builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromDays(7);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

    builder.Services.Configure<Smtp>(builder.Configuration.GetSection("Smtp"));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSerilogRequestLogging();
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days.
        // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    // middleware
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSession();

    app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapRazorPages();

    logger.Information("Starting Web Application...");
    app.Run();
}
catch (Exception ex)
{
    logger.Fatal(ex.Message, "Failed to start application.");
}
finally
{
    Log.CloseAndFlush();
}
