using Microsoft.Extensions.DependencyInjection;

namespace GitTracker.Infrastructure.Registrations
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            // TODO: Add the services
            //services.AddTransient<IService, Service>();

            return services;
        }
    }
}