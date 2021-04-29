using GitTracker.Domain.Contracts.Services;
using GitTracker.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitTracker.Tests.Services
{
    [TestClass]
    public class AppConfigurationTests
    {
        private IAppConfiguration _appConfiguration;

        [TestInitialize]
        public void TestInitialize()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _appConfiguration = new AppConfiguration(configuration);
        }

        [TestMethod]
        public void AppConfiguration_GetByKey_ShouldReturnValue()
        {
            // Arrange
            string expected = "GitTracker";

            // Act
            string response = _appConfiguration.GitHubAgent;

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(response));
            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public void AppConfiguration_GetByKey_NotConfigured_ShouldReturnDefaultValue()
        {
            // Arrange
            string expected = "DavidFTF";

            // Act
            string response = _appConfiguration.GitHubDefaultUser;

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(response));
            Assert.AreEqual(expected, response);
        }
    }
}