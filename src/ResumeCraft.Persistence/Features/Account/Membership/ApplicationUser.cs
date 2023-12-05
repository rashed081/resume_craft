using Microsoft.AspNetCore.Identity;
using ResumeCraft.Domain.Entities;
using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Persistence.Features.Account.Membership
{
    public class ApplicationUser : IdentityUser<Guid>, IApplicationUser
    {
        public string? FullName
        {
            get => FirstName + " " + LastName;
        }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }

        /// User is aggregate root so, DO NOT ADD ANY NAVIGATION PROPERTY
    }
}
