using Flurl.Http;
using Flurl.Http.Configuration;
using GitTracker.Domain.Contracts.Infrastructure;
using GitTracker.Infrastructure.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace GitTracker.Infrastructure.Registrations
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IFlurlClient, FlurlClient>();

            services.AddTransient<IEndPointParser, EndPointParser>();
            services.AddTransient<ISerializer, FlurlJsonSerializer>();
            services.AddTransient<IGitHubService, GitHubService>();

            return services;
        }
    }
}