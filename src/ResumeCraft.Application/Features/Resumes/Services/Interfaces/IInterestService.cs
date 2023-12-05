using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface IInterestService
    {
        Task<InterestDTO> AddIntoResumeAsync(Guid resumeId, InterestInputModel model);
        Task DeleteFromResumeAsync(Guid resumeId, Guid interestId);
        Task<IList<InterestDTO>> GetListOfInterestAsync(Guid resumeId);
        Task<InterestDTO> UpdateInterestAsync(Guid resumeId, Guid interestIdToUpdate, InterestInputModel model);
    }
}
