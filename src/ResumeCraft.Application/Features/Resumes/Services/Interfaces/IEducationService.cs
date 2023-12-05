using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface IEducationService
    {
        Task<EducationDTO> AddIntoResumeAsync(Guid resumeId, EducationInputModel model);
        Task DeleteFromResumeAsync(Guid resumeId, Guid educationIdToDelete);
        Task<IList<EducationDTO>> GetListOfEducationAsync(Guid resumeId);
        Task<EducationDTO> UpdateEducationAsync(Guid resumeId, Guid educationIdToUpdate, EducationInputModel model);
    }
}
