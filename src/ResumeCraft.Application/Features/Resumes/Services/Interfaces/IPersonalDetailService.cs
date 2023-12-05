using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface IPersonalDetailService
    {
        Task<PersonalDetailsDTO> AddIntoResumeAsync(Guid resumeId, PersonalDetailInputModel model);
        Task DeleteFromResumeAsync(Guid resumeId);
        Task<PersonalDetailsDTO> GetDetialsOfUserAsync(Guid resumeId);
        Task<PersonalDetailsDTO> UpdateDetailsAsync(Guid resumeId, PersonalDetailInputModel model);
        Task<PersonalDetailsDTO> UpdateDynamic(Guid resumeId, ContactUpdateModel model);
    }
}
