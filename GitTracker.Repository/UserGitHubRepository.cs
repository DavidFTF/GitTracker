using GitTracker.Domain.Contracts.Repository;
using GitTracker.Domain.Entities;
using GitTracker.Domain.Models;
using GitTracker.Repository.Base;
using GitTracker.Repository.EntityFramework;
using System.Threading.Tasks;

namespace GitTracker.Repository
{
    public class UserGitHubRepository : BaseRepository<UserGitHubEntity>, IUserGitHubRepository
    {
        public UserGitHubRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task CreateUserGitHub(UserGitHubModel userGitHub)
        {
            var userGitHubEntity = new UserGitHubEntity
            {
                Id = userGitHub.ApplicationUserId,
                DefaultRepository = userGitHub.DefaultRepository,
                Owner = userGitHub.Ownder
            };

            Add(userGitHubEntity);
            await SaveChangesAsync();
        }
    }
}