namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct AwardDTO()
    {
        public Guid Id { get; set; }
        public string? InstituteName { get; set; }
        public string? Title { get; set; }
    }
}
