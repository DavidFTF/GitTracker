using GitTracker.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitTracker.Domain.Contracts.Infrastructure
{
    public interface IGitHubService
    {
        Task<GitHubUserModel> GetUserInfo(string username);
        Task<IList<GitHubRepositoryModel>> GetRepositories(string username);
        Task<IList<GitHubBranchModel>> GetBranches(string username, string repository);
        Task<IList<GitHubCommitModel>> GetCommits(string username, string repository);
        Task<IList<GitHubCommitModel>> GetCommitsByBranch(string username, string repository, string branch);
    }
}