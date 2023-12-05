using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface IReferenceService
    {
        Task<ReferenceDTO> AddAsync(Guid resumeId, ReferenceInputModel model);
        Task DeleteAsync(Guid resumeId, Guid referenceIdToDelete);
        Task<IList<ReferenceDTO>> GetListAsync(Guid resumeId);
        Task<ReferenceDTO> UpdateAsync(Guid resumeId, Guid referenceIdToUpdate, ReferenceInputModel model);
    }
}
