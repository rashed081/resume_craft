namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct CertificationDTO()
    {
        public Guid Id { get; set; }
        public string? InstituteName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
    }
}
