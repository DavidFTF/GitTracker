using GitTracker.Domain.Models;
using System.Threading.Tasks;

namespace GitTracker.Domain.Contracts.Repository
{
    public interface IUserGitHubRepository
    {
        Task CreateUserGitHub(UserGitHubModel userGitHub);
    }
}