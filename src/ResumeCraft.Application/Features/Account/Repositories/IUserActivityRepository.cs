using ResumeCraft.Domain.Entities;
using ResumeCraft.Domain.Repositories;

namespace ResumeCraft.Application.Features.Account.Repositories
{
    public interface IUserActivityRepository : IRepositoryBase<UserActivityLog, Guid> { }
}
