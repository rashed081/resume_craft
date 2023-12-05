using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;

namespace ResumeCraft.Application.Features.Resumes.Services.Interfaces
{
    public interface ISummaryService
    {
        Task<SummaryDTO> AddAsync(Guid resumeId, SummaryInputModel model);
        Task DeleteAsync(Guid resumeId);
        Task<SummaryDTO> GetAsync(Guid resumeId);
        Task<SummaryDTO> UpdateAsync(Guid resumeId, string content);
    }
}
