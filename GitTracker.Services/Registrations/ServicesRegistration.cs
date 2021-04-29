using GitTracker.Domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GitTracker.Services.Registrations
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAppConfiguration, AppConfiguration>();
            services.AddTransient<IAccountService, AccountService>();

            return services;
        }
    }
}