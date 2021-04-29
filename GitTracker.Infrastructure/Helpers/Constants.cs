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

    public struct GitHubEndpoints
    {
        public const string GetUser = "users/{Username}";
        public const string GetRepositories = "users/{Username}/repos";
        public const string GetBranches = "repos/{Owner}/{Repo}/branches";
        public const string GetCommits = "repos/{Owner}/{Repo}/commits";
        public const string GetCommitsByBranch = "repos/{Owner}/{Repo}/commits?sha={Sha}";
    }
}