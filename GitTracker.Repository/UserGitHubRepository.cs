using GitTracker.Domain.Contracts.Repository;
using GitTracker.Domain.Entities;
using GitTracker.Domain.Models;
using GitTracker.Repository.Base;
using GitTracker.Repository.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GitTracker.Repository
{
    public class UserGitHubRepository : BaseRepository<UserGitHubEntity>, IUserGitHubRepository
    {
        public UserGitHubRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<UserGitHubModel> GetUserGitHub(string applicationUserId)
        {
            var userGitHubEntity = await Where(x => x.Id == applicationUserId)
                .FirstOrDefaultAsync();

            if (userGitHubEntity != null)
                return new UserGitHubModel(userGitHubEntity);
            else
                return null;
        }

        public async Task CreateUserGitHub(UserGitHubModel userGitHub)
        {
            var userGitHubEntity = new UserGitHubEntity
            {
                Id = userGitHub.ApplicationUserId,
                DefaultRepository = userGitHub.DefaultRepository,
                Owner = userGitHub.Owner
            };

            Add(userGitHubEntity);
            await SaveChangesAsync();
        }

        public async Task<bool> UpdateUserGitHub(UserGitHubModel userGitHub)
        {
            var userGitHubEntity = await Where(x => x.Id == userGitHub.ApplicationUserId)
                .FirstOrDefaultAsync();

            if (userGitHubEntity == null)
                return false;

            userGitHubEntity.DefaultRepository = userGitHub.DefaultRepository;
            userGitHubEntity.Owner = userGitHub.Owner;

            Update(userGitHubEntity);
            await SaveChangesAsync();

            return true;
        }
    }
}