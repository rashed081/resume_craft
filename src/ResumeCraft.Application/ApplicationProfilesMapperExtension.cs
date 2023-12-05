using Microsoft.Extensions.DependencyInjection;

namespace ResumeCraft.Application
{
    public static class ApplicationProfilesMapperExtension
    {
        public static IServiceCollection AddApplicationProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
