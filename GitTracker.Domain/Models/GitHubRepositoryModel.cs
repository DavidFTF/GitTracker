using System.Text.Json.Serialization;

namespace GitTracker.Domain.Models
{
    public class GitHubRepositoryModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("default_branch")]
        public string DefaultBranch { get; set; }
    }
}