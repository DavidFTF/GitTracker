using GitTracker.Domain.Entities;
using GitTracker.Repository.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitTracker.Repository.EntityFramework.Configurations
{
    public class UserGitHubConfiguration : BaseConfiguration<UserGitHubEntity>
    {
        public override void Configure(EntityTypeBuilder<UserGitHubEntity> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Owner)
                .HasMaxLength(39)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(x => x.DefaultRepository)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}