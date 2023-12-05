using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ResumeCraft.Api;
using ResumeCraft.Application;
using ResumeCraft.Domain.Entities.Email;
using ResumeCraft.Infrastructure;
using ResumeCraft.Persistence;
using ResumeCraft.Persistence.Database;
using Serilog;
using System.Text;

var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog(
        (context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        }
    );

    var connectionString =
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    var migrationAssembly = typeof(ApplicationDbContext).Assembly.FullName!;

    builder.Services.AddCors(p => p.AddPolicy("DomainPolicy", option =>
        {
            option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        })
    );

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ApplicationModule());
        containerBuilder.RegisterModule(new InfrastructureModule());
        containerBuilder.RegisterModule(new PersistenceModule(connectionString, migrationAssembly));
        containerBuilder.RegisterModule(new ApiModule());
    });

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddIdentityUser();
    builder.Services.AddApplicationProfiles();
    builder.Services.AddDinkToPdf();

    builder.Services
        .AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(
            JwtBearerDefaults.AuthenticationScheme,
            x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                };
            }
        );

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(swagger =>
    {
        swagger.SwaggerDoc(
            "v1",
            new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Version = "v1",
                Title = "ResumeCraft.API",
                Description = "Developed By Aspnet Team 1"
            }
        );
    });

    builder.Services.Configure<Smtp>(builder.Configuration.GetSection("Smtp"));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSerilogRequestLogging();
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    logger.Information("Starting API Application..");
    app.Run();
}
catch (Exception ex)
{
    logger.Fatal(ex, "Api service start-up failed.");
}
finally
{
    Log.CloseAndFlush();
}
