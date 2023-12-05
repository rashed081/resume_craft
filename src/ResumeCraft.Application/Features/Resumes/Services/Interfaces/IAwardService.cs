using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface IAwardService
    {
        Task<AwardDTO> AddAsync(Guid resumeId, AwardInputModel model);
        Task DeleteAsync(Guid resumeId, Guid awardIdToDelete);
        Task<IList<AwardDTO>> GetListAsync(Guid resumeId);
        Task<AwardDTO> UpdateAsync(Guid resumeId, Guid awardIdToUpdate, AwardInputModel model);
    }
}
