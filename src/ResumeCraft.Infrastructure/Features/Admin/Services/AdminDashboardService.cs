using ResumeCraft.Application.Features.Admin.Services;
using ResumeCraft.Application.Services.UnitOfWorks;

namespace ResumeCraft.Infrastructure.Features.Admin.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public AdminDashboardService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetResumeCountAsync()
        {
            return await _unitOfWork.Resumes.GetCountAsync();
        }
    }
}
