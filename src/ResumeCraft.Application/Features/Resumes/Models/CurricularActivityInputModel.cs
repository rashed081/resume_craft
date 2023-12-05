namespace ResumeCraft.Application.Features.Resumes.Models
{
    public class CurricularActivityInputModel
    {
        public Guid? Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Organization { get; set; }
        public string? Title { get; set; }
    }
}
