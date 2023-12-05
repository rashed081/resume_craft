using ResumeCraft.Domain.UnitOfWorks;
using ResumeCraft.Persistence.Repositories.User.Skeleton;

namespace ResumeCraft.Persistence.UnitOfWorks.Base
{
    public interface IApplicationUserUnitOfWork : IUnitOfWork
    {
        IApplicationUserRepository Users { get; }
    }
}
