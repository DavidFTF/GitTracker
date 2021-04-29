using GitTracker.Domain.Models;
using System.Threading.Tasks;

namespace GitTracker.Domain.Contracts.Repository
{
    public interface IUserGitHubRepository
    {
        Task<UserGitHubModel> GetUserGitHub(string applicationUserId);
        Task CreateUserGitHub(UserGitHubModel userGitHub);
        Task<bool> UpdateUserGitHub(UserGitHubModel userGitHub);
    }
}