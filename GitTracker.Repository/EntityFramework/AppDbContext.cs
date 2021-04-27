using GitTracker.Repository.EntityFramework.Configurations.Base;
using GitTracker.Repository.EntityFramework.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GitTracker.Repository.EntityFramework
{
    public partial class AppDbContext : IdentityDbContext<ApplicationUser>, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync(true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var type = typeof(IEntityConfiguration);

            var configurations = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass)
                .Where(x => !x.IsAbstract)
                .Where(x => type.IsAssignableFrom(x))
                .Select(x => Activator.CreateInstance(x) as IEntityConfiguration);

            foreach (var configuration in configurations)
                configuration?.AddConfiguration(modelBuilder);
        }
    }
}