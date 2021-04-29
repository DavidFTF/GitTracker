using Flurl.Http;
using Flurl.Http.Configuration;
using GitTracker.Domain.Contracts.Infrastructure;
using GitTracker.Domain.Contracts.Services;
using GitTracker.Infrastructure;
using GitTracker.Infrastructure.Helpers;
using GitTracker.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace GitTracker.Tests.Infrastructure
{
    [TestClass]
    public class GitHubServiceIntegrationTests
    {
        private const string GitHubUser = "DavidFTF";
        private const string GitHubRepository = "GitTracker";
        private const string GitHubBranch = "develop";
        private const string GitHubCommitSha = "946ef27fed131582f2b11cf1486a871384def7a5";

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
            var response = await gitHubService.GetUserInfo(GitHubUser);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(GitHubUser, response.Login);
        }

        [TestMethod]
        public async Task GetRepositories()
        {
            // Arrange
            var gitHubService = new GitHubService(_flurlClient, _serializer, _endPointParser, _appConfiguration);

            // Act
            var response = await gitHubService.GetRepositories(GitHubUser);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any(x => x.Name.Equals(GitHubRepository)));
        }

        [TestMethod]
        public async Task GetBranches()
        {
            // Arrange
            var gitHubService = new GitHubService(_flurlClient, _serializer, _endPointParser, _appConfiguration);

            // Act
            var response = await gitHubService.GetBranches(GitHubUser, GitHubRepository);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any(x => x.Name.Equals(GitHubBranch)));
        }

        [TestMethod]
        public async Task GetCommits()
        {
            // Arrange
            var gitHubService = new GitHubService(_flurlClient, _serializer, _endPointParser, _appConfiguration);

            // Act
            var response = await gitHubService.GetCommits(GitHubUser, GitHubRepository);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());

        }

        [TestMethod]
        public async Task GetCommitsByBranch()
        {
            // Arrange
            var gitHubService = new GitHubService(_flurlClient, _serializer, _endPointParser, _appConfiguration);

            // Act
            var response = await gitHubService.GetCommitsByBranch(GitHubUser, GitHubRepository, GitHubBranch);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any(x => x.Sha.Equals(GitHubCommitSha)));
        }
    }
}