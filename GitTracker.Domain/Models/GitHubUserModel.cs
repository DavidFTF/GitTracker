using System.Text.Json.Serialization;

namespace GitTracker.Domain.Models
{
    public class GitHubUserModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("login")]
        public string Login { get; set; }
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("html_url")]
        public string HomeUrl { get; set; }
        [JsonPropertyName("type")]
        public string UserType { get; set; }
        [JsonPropertyName("company")]
        public string Company { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}