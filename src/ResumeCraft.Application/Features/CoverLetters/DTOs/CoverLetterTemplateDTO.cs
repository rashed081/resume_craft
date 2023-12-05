namespace ResumeCraft.Application.Features.CoverLetters.DTOs
{
    public record struct CoverLetterTemplateDTO
    {
        public Guid Id { get; set; }
        public string? TemplateName { get; set; }
        public string? Path { get; set; }
    }
}
