using Microsoft.EntityFrameworkCore;
using ResumeCraft.Persistence.Database.Skeleton;
using ResumeCraft.Persistence.Features.Account.Membership;
using ResumeCraft.Persistence.Repositories.Base;
using ResumeCraft.Persistence.Repositories.User.Skeleton;

namespace ResumeCraft.Persistence.Repositories.User
{
    public class ApplicationUserRepository : Repository<ApplicationUser, Guid>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IApplicationDbContext context)
            : base((DbContext)context) { }
    }
}
