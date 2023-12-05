using ResumeCraft.Application.Features.CoverLetters.DTOs;
using ResumeCraft.Application.Features.CoverLetters.Models;

namespace ResumeCraft.Application.Features.CoverLetters.Services.Interface
{
    public interface IAsyncCoverLetterService
    {
        Task<CoverLetterDTO> AddAsync(Guid userId, Guid CoverLetterTemplateId, CoverLetterInputModel model);
        Task DeleteAsync(Guid coverLetterIdId);
        Task<IList<CoverLetterDTO>> GetListOfCoverLetterAsync();
        Task<CoverLetterDTO> UpdateTheCoverLetterAsync(Guid userId, Guid CoverLetterTemplateId, Guid coverLetterId, CoverLetterInputModel model);
        Task<Guid> AddEmptyCoverLetter(Guid userId, Guid CoverLetterTemplateId);
    }
}
