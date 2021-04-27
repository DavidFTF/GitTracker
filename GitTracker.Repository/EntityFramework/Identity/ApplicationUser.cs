using GitTracker.Domain.Entities;
using GitTracker.SharedKernel;
using Microsoft.AspNetCore.Identity;

namespace GitTracker.Repository.EntityFramework.Identity
{
    public class ApplicationUser : IdentityUser, IEntity
    {
        public UserGitHubEntity UserGitHub { get; set; }
    }
}