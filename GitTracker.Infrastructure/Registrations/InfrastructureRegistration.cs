using GitTracker.Domain.Contracts.Infrastructure;
using GitTracker.Infrastructure.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace GitTracker.Infrastructure.Registrations
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IEndPointParser, EndPointParser>();

            return services;
        }
    }
}