namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct ExperienceDTO()
    {
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Designation { get; set; }
        public string? Achievement { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
