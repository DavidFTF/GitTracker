using Flurl.Http;
using Flurl.Http.Configuration;
using GitTracker.Domain.Contracts.Infrastructure;
using GitTracker.Domain.Contracts.Services;
using GitTracker.Domain.Models;
using GitTracker.Infrastructure.Helpers;
using System.Threading.Tasks;

namespace GitTracker.Infrastructure
{
    public class GitHubService : IGitHubService
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IEndPointParser _endPointParser;

        public GitHubService(
            IFlurlClient flurlClient,
            ISerializer serializer,
            IEndPointParser endPointParser,
            IAppConfiguration appConfiguration)
        {
            _endPointParser = endPointParser;
            _flurlClient = flurlClient;

            _flurlClient.BaseUrl = appConfiguration.GitHubUrl;
            _flurlClient.WithHeader(Headers.Accept, MimeTypes.ApplicationGitHub);
            _flurlClient.WithHeader(Headers.UserAgent, appConfiguration.GitHubAgent);
            _flurlClient.Settings.JsonSerializer = serializer;
        }

        public async Task<GitHubUserModel> GetUserInfo(string username)
        {
            var endPointModel = new EndPointModel
            {
                Username = username
            };

            string endPoint = await _endPointParser.ParseEndpoint(endPointModel, GitHubEndpoints.GetUser);

            var response = await _flurlClient.Request(endPoint)
                .GetJsonAsync<GitHubUserModel>();

            return response;
        }

        public async Task<GitHubUserModel> GetBranches(string username)
        {
            var endPointModel = new EndPointModel
            {
                Username = username
            };

            string endPoint = await _endPointParser.ParseEndpoint(endPointModel, GitHubEndpoints.GetUser);

            var response = await _flurlClient.Request(endPoint)
                .GetJsonAsync<GitHubUserModel>();

            return response;
        }

        public async Task<GitHubUserModel> GetCommits(string username)
        {
            var endPointModel = new EndPointModel
            {
                Username = username
            };

            string endPoint = await _endPointParser.ParseEndpoint(endPointModel, GitHubEndpoints.GetUser);

            var response = await _flurlClient.Request(endPoint)
                .GetJsonAsync<GitHubUserModel>();

            return response;
        }

        public async Task<GitHubUserModel> GetCommitsByBranch(string username)
        {
            var endPointModel = new EndPointModel
            {
                Username = username
            };

            string endPoint = await _endPointParser.ParseEndpoint(endPointModel, GitHubEndpoints.GetUser);

            var response = await _flurlClient.Request(endPoint)
                .GetJsonAsync<GitHubUserModel>();

            return response;
        }
    }
}