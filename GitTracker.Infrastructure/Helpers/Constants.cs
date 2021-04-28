namespace GitTracker.Infrastructure.Helpers
{
    internal struct MimeTypes
    {
        internal const string ApplicationGitHub = "application/vnd.github.v3+json";
    }

    internal struct Headers
    {
        internal const string Accept = "accept";
        internal const string UserAgent = "User-Agent";
    }

    internal struct GitHubEndpoints
    {
        internal const string GetUser = "users/{Username}";
        internal const string GetRepositories = "users/{Username}/repos";
        internal const string GetBranches = "repos/{Owner}/{Repo}/branches";
        internal const string GetCommits = "repos/{Owner}/{Repo}/commits";
        internal const string GetCommitsByBranch = "repos/{Owner}/{Repo}/commits?sha={Sha}";
    }
}