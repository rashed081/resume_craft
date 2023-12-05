using ResumeCraft.Application.Features.PdfGenerate.DTOs;
using ResumeCraft.Application.Features.PdfGenerate.Models;

namespace ResumeCraft.Application.Features.PdfGenerate.Services
{
    public interface IAsyncPdfGenerationService
    {
        Task<FileDTO> GeneratePdfObjectAsync(FileInputModel model);
    }
}
