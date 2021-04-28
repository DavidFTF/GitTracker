using System;
using System.Text.Json.Serialization;

namespace GitTracker.Domain.Models
{
    public class GitHubCommitModel
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("sha")]
        public string Sha { get; set; }

        [JsonPropertyName("commit")]
        public CommitInfoModel Commit { get; set; }
    }

    public class CommitInfoModel
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("author")]
        public CommitUserModel Author { get; set; }

        [JsonPropertyName("committer")]
        public CommitUserModel Committer { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }
    }

    public class CommitUserModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}