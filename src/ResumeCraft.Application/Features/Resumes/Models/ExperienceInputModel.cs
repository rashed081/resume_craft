namespace ResumeCraft.Application.Features.Resumes.Models
{
    public class ExperienceInputModel
    {
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Designation { get; set; }
        public string? Achievement { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
