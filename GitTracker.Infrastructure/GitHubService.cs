using Flurl.Http;
using GitTracker.Domain.Contracts.Infrastructure;
using GitTracker.Domain.Contracts.Services;

namespace GitTracker.Infrastructure
{
    public class GitHubService : IGitHubService
    {
        private readonly IFlurlClient _httpClient;

        public GitHubService(
            IFlurlClient flurlClient,
            IAppConfiguration appConfiguration)
        {
            _httpClient = flurlClient;

            _httpClient.BaseUrl = appConfiguration.GitHubUrl;
        }
    }
}