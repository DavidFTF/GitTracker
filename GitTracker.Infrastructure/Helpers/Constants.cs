namespace GitTracker.Infrastructure.Helpers
{
    internal struct GitHubEndpoints
    {
        internal const string GetUser = "users/{Username}";
        internal const string GetBranches = "/repos/{Owner}/{Repo}/branches";
        internal const string GetCommits = "/repos/{Owner}/{Repo}/commits";
        internal const string GetCommitsByBranch = "/repos/{Owner}/{Repo}/commits?sha={Sha}";
    }
}