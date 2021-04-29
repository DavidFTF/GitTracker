using GitTracker.Domain.Contracts.Infrastructure;
using GitTracker.Domain.Contracts.Repository;
using GitTracker.Domain.Models;
using GitTracker.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitTracker.Tests.Services
{
    [TestClass]
    public class AccountServiceTests
    {
        private readonly Mock<IUserGitHubRepository> _userGitHubRepository = new();
        private readonly Mock<IGitHubService> _gitHubService = new();

        private readonly UserGitHubModel _userGitHubModel = new()
        {
            ApplicationUserId = "Valid",
            DefaultRepository = "Default",
            Owner = "Someone"
        };
        private readonly GitHubUserModel _gitHubUserModel = new()
        {
            AvatarUrl = "AvatarUrl",
            Company = "Company",
            Email = "Email",
            HomeUrl = "HomeUrl",
            Id = 1,
            Login = "Someone",
            Url = "Url",
            UserType = "UserType"
        };
        private readonly GitHubBranchModel _gitHubBranchModel = new()
        {
            Name = "Branch",
            Protected = true
        };
        private readonly IList<GitHubRepositoryModel> _gitHubRepositories = new List<GitHubRepositoryModel>()
        {
            new GitHubRepositoryModel
            {
                Id = 1,
                Name = "Repo1",
                DefaultBranch = "Master"
            },
            new GitHubRepositoryModel
            {
                Id = 2,
                Name = "Repo2",
                DefaultBranch = "Develop"
            },
        };

        [TestInitialize]
        public void TestInitialize()
        {
            _userGitHubRepository.Setup(x => x.GetUserGitHub(It.Is<string>(x => x == "Valid")))
                .ReturnsAsync(_userGitHubModel);
            _userGitHubRepository.Setup(x => x.GetUserGitHub(It.Is<string>(x => x != "Valid")))
                .ReturnsAsync(null, new System.TimeSpan(10));
            _userGitHubRepository.Setup(x => x.CreateUserGitHub(It.IsAny<UserGitHubModel>()))
                .Returns(Task.CompletedTask);
            _userGitHubRepository.Setup(x => x.UpdateUserGitHub(It.Is<UserGitHubModel>(x => x.ApplicationUserId == "Valid")))
                .ReturnsAsync(true);
            _userGitHubRepository.Setup(x => x.UpdateUserGitHub(It.Is<UserGitHubModel>(x => x.ApplicationUserId != "Valid")))
                .ReturnsAsync(false);

            _gitHubService.Setup(x => x.GetUserInfo(It.Is<string>(x => x == "Someone")))
                .ReturnsAsync(_gitHubUserModel);
            _gitHubService.Setup(x => x.GetRepositories(It.Is<string>(x => x == "Someone")))
                .ReturnsAsync(_gitHubRepositories);
            _gitHubService.Setup(x => x.GetBranches(It.Is<string>(x => x == "Someone"), It.Is<string>(x => x == "Branch")))
                .ReturnsAsync(new List<GitHubBranchModel> { _gitHubBranchModel });
        }

        [TestMethod]
        public async Task GetGitHubInfo_Valid_ShouldReturnObject()
        {
            // Arrange
            var accountService = new AccountService(_userGitHubRepository.Object, _gitHubService.Object);
            var expected = _userGitHubModel;

            // Act
            var response = await accountService.GetGitHubInfo(_userGitHubModel.ApplicationUserId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(expected.ApplicationUserId, response.ApplicationUserId);
            Assert.AreEqual(expected.DefaultRepository, response.DefaultRepository);
            Assert.AreEqual(expected.Owner, response.Owner);
        }

        [TestMethod]
        public async Task GetGitHubInfo_Invalid_ShouldReturnNull()
        {
            // Arrange
            var accountService = new AccountService(_userGitHubRepository.Object, _gitHubService.Object);
            string invalidApplicationId = "NotRegistered";

            // Act
            var response = await accountService.GetGitHubInfo(invalidApplicationId);

            // Assert
            Assert.IsNull(response);
        }

        [TestMethod]
        public async Task AddGitHubInfo_ValidCreate_ShouldReturnTrue()
        {
            // Arrange
            var accountService = new AccountService(_userGitHubRepository.Object, _gitHubService.Object);
            var userGitHubModel = new UserGitHubModel
            {
                ApplicationUserId = "Valid",
                DefaultRepository = "Repo1",
                Owner = "Someone"
            };

            // Act
            bool response = await accountService.AddGitHubInfo(userGitHubModel);

            // Assert
            Assert.IsTrue(response);
        }

        [TestMethod]
        public async Task AddGitHubInfo_InvalidUser_ShouldReturnFalse()
        {
            // Arrange
            var accountService = new AccountService(_userGitHubRepository.Object, _gitHubService.Object);
            var userGitHubModel = new UserGitHubModel
            {
                ApplicationUserId = "Valid",
                DefaultRepository = "Repo1",
                Owner = "IDontExist"
            };

            // Act
            bool response = await accountService.AddGitHubInfo(userGitHubModel);

            // Assert
            Assert.IsFalse(response);
        }

        [TestMethod]
        public async Task AddGitHubInfo_ValidUser_InvalidRepo_ShouldReturnTrue()
        {
            // Arrange
            var accountService = new AccountService(_userGitHubRepository.Object, _gitHubService.Object);
            var userGitHubModel = new UserGitHubModel
            {
                ApplicationUserId = "Valid",
                DefaultRepository = "NoRepo",
                Owner = "Someone"
            };

            // Act
            bool response = await accountService.AddGitHubInfo(userGitHubModel);

            // Assert
            Assert.IsTrue(response);
        }
    }
}