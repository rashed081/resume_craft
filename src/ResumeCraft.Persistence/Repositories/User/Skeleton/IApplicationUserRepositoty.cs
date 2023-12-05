using ResumeCraft.Domain.Repositories;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Persistence.Repositories.User.Skeleton
{
    public interface IApplicationUserRepository : IRepositoryBase<ApplicationUser, Guid> { }
}
