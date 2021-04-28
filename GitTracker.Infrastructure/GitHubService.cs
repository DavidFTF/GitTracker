using Flurl.Http;
using Flurl.Http.Configuration;
using GitTracker.Domain.Contracts.Infrastructure;
using GitTracker.Domain.Contracts.Services;
using GitTracker.Domain.Models;
using GitTracker.Infrastructure.Helpers;
using System.Collections.Generic;
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

        public async Task<IList<GitHubRepositoryModel>> GetRepositories(string username)
        {
            var endPointModel = new EndPointModel
            {
                Username = username
            };

            string endPoint = await _endPointParser.ParseEndpoint(endPointModel, GitHubEndpoints.GetRepositories);

            var response = await _flurlClient.Request(endPoint)
                .GetJsonAsync<IList<GitHubRepositoryModel>>();

            return response;
        }

        public async Task<IList<GitHubBranchModel>> GetBranches(string username, string repository)
        {
            var endPointModel = new EndPointModel
            {
                Owner = username,
                Repo = repository
            };

            string endPoint = await _endPointParser.ParseEndpoint(endPointModel, GitHubEndpoints.GetBranches);

            var response = await _flurlClient.Request(endPoint)
                .GetJsonAsync<IList<GitHubBranchModel>>();

            return response;
        }

        public async Task<IList<GitHubCommitModel>> GetCommits(string username, string repository)
        {
            var endPointModel = new EndPointModel
            {
                Owner = username,
                Repo = repository
            };

            string endPoint = await _endPointParser.ParseEndpoint(endPointModel, GitHubEndpoints.GetCommits);

            var response = await _flurlClient.Request(endPoint)
                .GetJsonAsync<IList<GitHubCommitModel>>();

            return response;
        }

        public async Task<IList<GitHubCommitModel>> GetCommitsByBranch(string username, string repository, string branch)
        {
            var endPointModel = new EndPointModel
            {
                Owner = username,
                Repo = repository,
                Sha = branch
            };

            string endPoint = await _endPointParser.ParseEndpoint(endPointModel, GitHubEndpoints.GetCommitsByBranch);

            var response = await _flurlClient.Request(endPoint)
                .GetJsonAsync<IList<GitHubCommitModel>>();

            return response;
        }
    }
}