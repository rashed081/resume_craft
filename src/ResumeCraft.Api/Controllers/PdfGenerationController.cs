using DinkToPdf;
using ResumeCraft.Application.Features.PdfGenerate.DTOs;
using ResumeCraft.Application.Features.PdfGenerate.Models;
using ResumeCraft.Application.Features.PdfGenerate.Services;

namespace ResumeCraft.Api.Controllers
{
    // [Authorize(Roles = "User")]
    public class PdfGenerationController : ApiController
    {
        private readonly ILogger<PdfGenerationController> _logger;
        private readonly IAsyncPdfGenerationService _pdfGenerationService;

        public PdfGenerationController(ILogger<PdfGenerationController> logger, IAsyncPdfGenerationService pdfGenerationService)
        {
            _logger = logger;
            _pdfGenerationService = pdfGenerationService;
        }

        [HttpPost("CoverLetter")]
        public async Task<IActionResult> CovertLetterPdfGeneration([FromBody] FileInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                model.PaperKind = PaperKind.Letter;
                var pdfFile = await _pdfGenerationService.GeneratePdfObjectAsync(model);
                var fileUrl = await UploadPdfFileAsync(pdfFile);

                return Ok(fileUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't Create PDF");
            }
            return BadRequest();
        }

        [HttpPost("Resume")]
        public async Task<IActionResult> ResumePdfGeneration([FromBody] FileInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var pdfFile = await _pdfGenerationService.GeneratePdfObjectAsync(model);
                var fileUrl = await UploadPdfFileAsync(pdfFile);

                return Ok(fileUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't Create PDF");
            }
            return BadRequest();
        }

        private async Task<string> UploadPdfFileAsync(FileDTO file)
        {
            var pdfDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName + $"\\ResumeCraft.Web\\wwwroot\\pdffiles";
            var pdfFile = $"{pdfDirectory}\\{file.FileName}";
            var webHost = "localhost:7176";
            var fileName = file.FileName.ToLower().EndsWith(".pdf") ? file.FileName : file.FileName + ".pdf";
            var url = $"{Request.Scheme}://{webHost}/pdffiles/{fileName}";

            if (!Directory.Exists(pdfDirectory))
            {
                Directory.CreateDirectory(pdfDirectory);
            }

            if (System.IO.File.Exists(pdfFile))
            {
                return url;
            }

            using var fileStream = new FileStream(pdfFile, FileMode.Create);

            try
            {
                await fileStream.WriteAsync(file.PdfBytes);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while uploading PDF files: {ex.Message}", ex.Message);
            }
            finally
            {
                fileStream.Close();
            }

            return url;
        }
    }
}
