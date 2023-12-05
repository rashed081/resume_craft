namespace ResumeCraft.Application.Features.Resumes.Models
{
    public class CertificationInputModel
    {
        public Guid? Id { get; set; } = null!;
        public string? InstituteName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Title { get; set; }
    }
}
