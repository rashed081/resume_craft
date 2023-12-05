using ResumeCraft.Application.Features.Resumes.DTOs;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface IResumeTemplateService
    {
        Task<ResumeDTO> GetResumeOfUser(Guid userId, Guid resumeId);
    }
}
