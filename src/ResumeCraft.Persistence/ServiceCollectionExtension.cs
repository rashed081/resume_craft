using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ResumeCraft.Persistence.Database;
using ResumeCraft.Persistence.DinkToPdf;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Persistence
{
    public static class ServiceCollectionExtension
    {
        public static void AddIdentityUser(this IServiceCollection services)
        {
            services
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<ApplicationUserManager>()
                .AddRoleManager<ApplicationRoleManager>()
                .AddSignInManager<ApplicationSignInManager>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(05);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789-._@";
                options.User.RequireUniqueEmail = true;
            });
        }

        public static void AddDinkToPdf(this IServiceCollection services)
        {
            if (services != null)
            {
                var architectureFolder = nint.Size == 8 ? "64 bit" : "32 bit";
                var wkHtmlToPdfPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    $"DinkToPdf\\wkhtmltox\\v0.12.4\\{architectureFolder}\\libwkhtmltox"
                );

                var context = new CustomAssemblyLoadContext();
                context.LoadUnmanagedLibrary(wkHtmlToPdfPath);
            }
        }
    }
}
