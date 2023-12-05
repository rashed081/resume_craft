using ResumeCraft.Application.Features.Admin.Services;
using ResumeCraft.Application.Services.UnitOfWorks;
using ResumeCraft.Domain.Entities;

namespace ResumeCraft.Infrastructure.Features.Admin.Services
{
    public class AdminProfileService : IAdminProfileService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public AdminProfileService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Resume> GetEducationsAsync(Guid adminId)
        {
            var resume = await _unitOfWork.Resumes.GetResumeWithRelatedDataByUserAsync(adminId);
            if (resume == null)
            {
                resume = new Resume() { UserId = adminId, Name = "AdminResume", };
                await _unitOfWork.Resumes.AddAsync(resume);
                await _unitOfWork.SaveAsync();
                resume = await _unitOfWork.Resumes.GetResumeWithRelatedDataByUserAsync(adminId);
            }
            return resume;
        }
    }
}
