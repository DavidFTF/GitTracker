using Microsoft.Extensions.DependencyInjection;

namespace GitTracker.Repository.Registrations
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            // TODO: Add the services
            //services.AddTransient<IService, Service>();

            return services;
        }
    }
}