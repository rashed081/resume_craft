using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface IPublicationService
    {
        Task<PublicationDTO> AddIntoResumeAsync(Guid resumeId, PublicationInputModel model);
        Task DeleteFromResumeAsync(Guid resumeId, Guid publicationIdToDelete);
        Task<IList<PublicationDTO>> GetListOfPublicationAsync(Guid resumeId);
        Task<PublicationDTO> UpdateThePublicationAsync(Guid resumeId, Guid publicationIdToUpdate, PublicationInputModel model);
    }
}
