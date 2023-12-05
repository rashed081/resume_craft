namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct EducationDTO()
    {
        public Guid Id { get; set; }
        public Guid ResumeId { get; set; }
        public string InstituteName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? Grade { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
