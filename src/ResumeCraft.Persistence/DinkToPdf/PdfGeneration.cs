using DinkToPdf;
using DinkToPdf.Contracts;
using ResumeCraft.Application.Features.PdfGenerate.DTOs;
using ResumeCraft.Application.Features.PdfGenerate.Models;

namespace ResumeCraft.Persistence.DinkToPdf
{
    public static class PdfGeneration
    {
        public static FileDTO GeneratePdfBytes(IConverter converter, FileInputModel model)
        {
            var document = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    PaperSize = model.PaperKind,
                    Orientation = Orientation.Portrait,
                    Margins = new MarginSettings
                    {
                        Top = 0,
                        Bottom = 0,
                        Left = 0,
                        Right = 0
                    } /*,
                    DPI = 300,*/
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HtmlContent = model.HtmlContent,
                        LoadSettings = { ZoomFactor = model.ZoomFactor, }
                    }
                }
            };

            var pdfFileByte = converter.Convert(document);

            return new FileDTO { FileName = model.FileName, PdfBytes = pdfFileByte };
        }
    }
}
