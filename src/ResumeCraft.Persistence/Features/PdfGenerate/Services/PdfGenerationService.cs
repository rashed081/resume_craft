using DinkToPdf.Contracts;
using Microsoft.Extensions.Logging;
using ResumeCraft.Application.Features.PdfGenerate.DTOs;
using ResumeCraft.Application.Features.PdfGenerate.Models;
using ResumeCraft.Application.Features.PdfGenerate.Services;
using ResumeCraft.Persistence.DinkToPdf;

namespace ResumeCraft.Persistence.Features.PdfGenerate.Services
{
    public class PdfGenerationService : IAsyncPdfGenerationService
    {
        private readonly ILogger<PdfGenerationService> _logger;
        private readonly IConverter _converter;

        public PdfGenerationService(ILogger<PdfGenerationService> logger, IConverter converter)
        {
            _logger = logger;
            _converter = converter;
        }

        public async Task<FileDTO> GeneratePdfObjectAsync(FileInputModel model)
        {
            //throw new NotImplementedException();
            try
            {
                return await Task.Run(() =>
                {
                    var pdfFile = PdfGeneration.GeneratePdfBytes(_converter, model);
                    return pdfFile;
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
