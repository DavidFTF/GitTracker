using Microsoft.Extensions.DependencyInjection;

namespace GitTracker.Services.Registrations
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // TODO: Add the services
            //services.AddTransient<IService, Service>();

            return services;
        }
    }
}