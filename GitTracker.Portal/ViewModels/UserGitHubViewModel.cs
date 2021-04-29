using GitTracker.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace GitTracker.Portal.ViewModels
{
    public class UserGitHubViewModel
    {
        public UserGitHubViewModel() { }

        public UserGitHubViewModel(UserGitHubModel model)
        {
            ApplicationUserId = model.ApplicationUserId;
            DefaultRepository = model.DefaultRepository;
            Owner = model.Owner;
        }

        public string ApplicationUserId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string DefaultRepository { get; set; }
        [Required]
        [StringLength(39, MinimumLength = 1)]
        public string Owner { get; set; }
    }
}