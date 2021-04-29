using Microsoft.EntityFrameworkCore;

namespace GitTracker.Repository.EntityFramework.Configurations.Base
{
    public interface IEntityConfiguration
    {
        void AddConfiguration(ModelBuilder builder);
    }
}