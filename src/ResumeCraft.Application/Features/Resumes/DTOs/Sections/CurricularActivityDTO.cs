namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct CurricularActivityDTO()
    {
        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Title { get; set; }
        public string? Organization { get; set; }
    }
}
