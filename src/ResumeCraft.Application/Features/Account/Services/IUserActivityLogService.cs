using ResumeCraft.Domain.Entities;
using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Application.Features.Account.Services
{
    public interface IUserActivityLogService
    {
        Task AddAsync(DateTime date, string userIp, UserOperation action, string description, Guid userId);
        Task DeleteAsync(Guid id);
        Task<UserActivityLog> GetAsync(Guid id);
        Task<IList<UserActivityLog>> GetAllAsync();
    }
}
