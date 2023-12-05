using DinkToPdf;
using ResumeCraft.Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.PdfGenerate.Models
{
    public class FileInputModel
    {
        public string FileName { get; set; } =
            CustomRegex.Replace(CustomRegex.PdfFileName, String.Format("Document_{0}.pdf", DateTime.Now.Ticks).ToString(), "_"); // Document_638339455059479621.pdf
        public double ZoomFactor { get; set; } = 2.0;
        public PaperKind PaperKind { get; set; } = PaperKind.A4;

        [Required]
        public string HtmlContent { get; set; } = string.Empty;
    }
}
