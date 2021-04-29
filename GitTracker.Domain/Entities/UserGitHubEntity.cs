using GitTracker.SharedKernel;

namespace GitTracker.Domain.Entities
{
    public class UserGitHubEntity : IEntity<string>
    {
        public string Id { get; set; }
        public string Owner { get; set; }
        public string DefaultRepository { get; set; }
    }
}