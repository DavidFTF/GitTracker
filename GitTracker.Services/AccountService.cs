using GitTracker.Domain.Contracts.Infrastructure;
using GitTracker.Domain.Contracts.Repository;
using GitTracker.Domain.Contracts.Services;
using GitTracker.Domain.Models;
using System.Threading.Tasks;

namespace GitTracker.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserGitHubRepository _userGitHubRepository;
        private readonly IGitHubService _gitHubService;

        public AccountService(
            IUserGitHubRepository userGitHubRepository,
            IGitHubService gitHubService)
        {
            _userGitHubRepository = userGitHubRepository;
            _gitHubService = gitHubService;
        }

        public async Task<bool> AddGitHubInfo(UserGitHubModel userGitHub)
        {
            var gitHubUser = await _gitHubService.GetUserInfo(userGitHub.Owner);

            if (gitHubUser != null)
            {
                await _userGitHubRepository.CreateUserGitHub(userGitHub);

                return true;
            }
            else
                return false;
        }
    }
}