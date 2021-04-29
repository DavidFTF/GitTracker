using System.Text.Json.Serialization;

namespace GitTracker.Domain.Models
{
    public class GitHubBranchModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("protected")]
        public bool Protected { get; set; }
    }
}