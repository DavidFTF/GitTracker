using GitTracker.Infrastructure.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace GitTracker.Tests.Infrastructure
{
    [TestClass]
    public class EndPointParserTests
    {
        private const string Username = "User";
        private const string Repository = "Repo";

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public async Task ParseEndpoint_SingleValue()
        {
            // Arrange
            var endPointParser = new EndPointParser();
            string expected = GitHubEndpoints.GetUser.Replace("{Username}", Username);
            var parseObject = new { Username };

            // Act
            string response = await endPointParser.ParseEndpoint(parseObject, GitHubEndpoints.GetUser);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(response));
            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public async Task ParseEndpoint_MultipleValues()
        {
            // Arrange
            var endPointParser = new EndPointParser();
            string expected = GitHubEndpoints.GetBranches.Replace("{Owner}", Username).Replace("{Repo}", Repository);
            var parseObject = new { Owner = Username, Repo = Repository };

            // Act
            string response = await endPointParser.ParseEndpoint(parseObject, GitHubEndpoints.GetBranches);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(response));
            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public async Task ParseEndpoint_MultipleValues_InvalidObject()
        {
            // Arrange
            var endPointParser = new EndPointParser();
            string expected = GitHubEndpoints.GetBranches.Replace("{Repo}", Repository);
            var parseObject = new { NonExistantValue = Username, Repo = Repository };

            // Act
            string response = await endPointParser.ParseEndpoint(parseObject, GitHubEndpoints.GetBranches);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(response));
            Assert.AreEqual(expected, response);
        }
    }
}