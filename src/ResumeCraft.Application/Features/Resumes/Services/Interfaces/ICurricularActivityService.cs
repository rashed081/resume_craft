using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface ICurricularActivityService
    {
        Task<CurricularActivityDTO> AddIntoResumeAsync(Guid resumeId, CurricularActivityInputModel model);
        Task DeleteFromResumeAsync(Guid resumeId, Guid curricularActivityIdToDelete);
        Task<IList<CurricularActivityDTO>> GetListOfCurricularActivityAsync(Guid resumeId);
        Task<CurricularActivityDTO> UpdateTheCurricularActivityAsync(
            Guid resumeId,
            Guid curricularActivityIdToUpdate,
            CurricularActivityInputModel model
        );
    }
}
