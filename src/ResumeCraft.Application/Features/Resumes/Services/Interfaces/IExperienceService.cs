using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface IExperienceService
    {
        Task<ExperienceDTO> AddAsync(Guid resumeId, ExperienceInputModel model);
        Task DeleteAsync(Guid resumeId, Guid experienceId);
        Task<IList<ExperienceDTO>> GetListAsync(Guid resumeId);
        Task<ExperienceDTO> UpdateAsync(Guid resumeId, Guid experienceId, ExperienceInputModel model);
    }
}
