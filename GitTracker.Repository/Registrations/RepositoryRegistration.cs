using GitTracker.Domain.Contracts.Repository;
using GitTracker.Repository.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GitTracker.Repository.Registrations
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.TryAddScoped<IAppDbContext, AppDbContext>();

            services.AddScoped<IUserGitHubRepository, UserGitHubRepository>();

            return services;
        }
    }
}