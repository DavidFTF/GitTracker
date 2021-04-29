using GitTracker.Domain.Models;
using System.Threading.Tasks;

namespace GitTracker.Domain.Contracts.Services
{
    public interface IAccountService
    {
        Task<bool> AddGitHubInfo(UserGitHubModel userGitHub);
        Task<UserGitHubModel> GetGitHubInfo(string applicationUserId);
    }
}