using ResumeCraft.Application.Features.Resumes.DTOs;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface IResumesService
    {
        Task<Guid> CreateEmptyResumeAsync(Guid userId);
        Task DeleteResumeAsync(Guid resumeId);
        Task<bool> ExistsAsync(Guid resumeId);
        Task<IList<ResumeListDto>> GetListOfResumeAsync(Guid userId);
    }
}
