using ResumeCraft.Application.Features.Account.Services;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities;
using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Infrastructure.Features.Account.Services
{
    public class UserActivityLogService : IUserActivityLogService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public UserActivityLogService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(DateTime date, string userIp, UserOperation action, string description, Guid userId)
        {
            var userActivityLog = new UserActivityLog()
            {
                Date = date,
                UserId = userId,
                UserIp = userIp,
                Action = action,
                Description = description
            };

            await _unitOfWork.UserActivityLogs.AddAsync(userActivityLog);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.UserActivityLogs.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<UserActivityLog> GetAsync(Guid id)
        {
            return await _unitOfWork.UserActivityLogs.GetByIdAsync(id);
        }

        public async Task<IList<UserActivityLog>> GetAllAsync()
        {
            return await _unitOfWork.UserActivityLogs.GetAllAsync();
        }
    }
}
