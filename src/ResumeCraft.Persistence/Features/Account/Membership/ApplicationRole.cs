using Microsoft.AspNetCore.Identity;

namespace ResumeCraft.Persistence.Features.Account.Membership
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
            : base() { }

        public ApplicationRole(string roleName)
            : base(roleName) { }
    }
}
