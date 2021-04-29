using GitTracker.Domain.Entities;
using GitTracker.Repository.EntityFramework.Configurations.Base;
using GitTracker.Repository.EntityFramework.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitTracker.Repository.EntityFramework.Configurations
{
    public class ApplicationUserConfiguration : BaseConfiguration<ApplicationUser>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserGitHub)
                .WithOne()
                .HasForeignKey<UserGitHubEntity>(x => x.Id);
        }
    }
}