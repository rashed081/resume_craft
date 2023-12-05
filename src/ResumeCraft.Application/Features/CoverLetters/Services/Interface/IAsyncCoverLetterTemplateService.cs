using ResumeCraft.Application.Features.CoverLetters.DTOs;

namespace ResumeCraft.Application.Features.CoverLetters.Services.Interface
{
    public interface IAsyncCoverLetterTemplateService
    {
        Task<CoverLetterTemplateDTO> AddAsync(string templateName, string path);
        Task DeleteAsync(Guid id);
        Task<CoverLetterTemplateDTO> GetAsync(Guid id);
        Task<IList<CoverLetterTemplateDTO>> GetAllAsync();
        Task<CoverLetterTemplateDTO> UpdateAsync(Guid id, string templateName, string path);
    }
}
