namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct SummaryDTO()
    {
        public Guid? Id { get; set; }
        public string? Content { get; set; }
    }
}
