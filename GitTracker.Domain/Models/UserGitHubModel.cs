using GitTracker.Domain.Entities;

namespace GitTracker.Domain.Models
{
    public class UserGitHubModel
    {
        public UserGitHubModel() { }

        public UserGitHubModel(UserGitHubEntity userGitHubEntity)
        {
            ApplicationUserId = userGitHubEntity?.Id;
            DefaultRepository = userGitHubEntity?.DefaultRepository;
            Owner = userGitHubEntity?.Owner;
        }

        public string ApplicationUserId { get; set; }
        public string DefaultRepository { get; set; }
        public string Owner { get; set; }
    }
}