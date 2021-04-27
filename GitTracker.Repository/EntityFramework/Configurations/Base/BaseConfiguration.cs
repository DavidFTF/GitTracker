using GitTracker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;

namespace GitTracker.Repository.EntityFramework.Configurations.Base
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T>, IEntityConfiguration where T : class, IEntity
    {
        public void AddConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(this);
        }

        protected string GetEntityName()
        {
            return typeof(T).Name.Replace("Entity", "");
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(GetEntityName());
            Debug.WriteLine("Table: " + GetEntityName());

            CustomConfigure(builder);
        }

        public virtual void CustomConfigure(EntityTypeBuilder<T> builder)
        {
        }
    }
}