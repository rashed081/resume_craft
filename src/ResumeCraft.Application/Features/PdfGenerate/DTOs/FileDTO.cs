namespace ResumeCraft.Application.Features.PdfGenerate.DTOs
{
    public record struct FileDTO
    {
        public required string FileName { get; set; }
        public required byte[] PdfBytes { get; set; }
    }
}
