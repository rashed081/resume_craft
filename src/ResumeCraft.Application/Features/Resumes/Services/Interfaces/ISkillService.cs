using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface ISkillService
    {
        Task<SkillDTO> AddAsync(Guid resumeId, SkillInputModel model);
        Task DeleteAsync(Guid resumeId, Guid skillIdToDelete);
        Task<IList<SkillDTO>> GetListAsync(Guid resumeId);
        Task<SkillDTO> UpdateAsync(Guid resumeId, Guid skillIdToUpdate, SkillInputModel model);
    }
}
