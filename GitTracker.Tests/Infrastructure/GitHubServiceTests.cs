using Flurl.Http;
using Flurl.Http.Configuration;
using GitTracker.Domain.Contracts.Infrastructure;
using GitTracker.Domain.Contracts.Services;
using GitTracker.Infrastructure;
using GitTracker.Infrastructure.Helpers;
using GitTracker.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace GitTracker.Tests.Infrastructure
{
    [TestClass]
    public class GitHubServiceTests
    {
        private IFlurlClient _flurlClient;
        private ISerializer _serializer;
        private IEndPointParser _endPointParser;
        private IAppConfiguration _appConfiguration;

        [TestInitialize]
        public void TestInitialize()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _flurlClient = new FlurlClient();
            _serializer = new FlurlJsonSerializer();
            _endPointParser = new EndPointParser();
            _appConfiguration = new AppConfiguration(configuration);
        }

        [TestMethod]
        public async Task GetUserInfo()
        {
            // Arrange
            var gitHubService = new GitHubService(_flurlClient, _serializer, _endPointParser, _appConfiguration);

            // Act
            _ = await gitHubService.GetUserInfo("DavidFTF");

            // Assert
        }

        [TestMethod]
        public async Task GetBranches()
        {
            // Arrange
            var gitHubService = new GitHubService(_flurlClient, _serializer, _endPointParser, _appConfiguration);

            // Act
            _ = await gitHubService.GetBranches("DavidFTF", "GitTracker");

            // Assert
        }

        [TestMethod]
        public async Task GetCommits()
        {
            // Arrange
            var gitHubService = new GitHubService(_flurlClient, _serializer, _endPointParser, _appConfiguration);

            // Act
            _ = await gitHubService.GetCommits("DavidFTF", "GitTracker");

            // Assert
        }

        [TestMethod]
        public async Task GetCommitsByBranch()
        {
            // Arrange
            var gitHubService = new GitHubService(_flurlClient, _serializer, _endPointParser, _appConfiguration);

            // Act
            _ = await gitHubService.GetCommitsByBranch("DavidFTF", "GitTracker", "develop");

            // Assert
        }
    }
}