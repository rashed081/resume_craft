using ResumeCraft.Application.Features.Account.Repositories;
using ResumeCraft.Domain.Entities;
using ResumeCraft.Persistence.Database;
using ResumeCraft.Persistence.Database.Skeleton;
using ResumeCraft.Persistence.Repositories.Base;

namespace ResumeCraft.Persistence.Features.Account.Repositories
{
    public class UserActivityLogsRepository : Repository<UserActivityLog, Guid>, IUserActivityRepository
    {
        public UserActivityLogsRepository(IApplicationDbContext context)
            : base((ApplicationDbContext)context) { }
    }
}
