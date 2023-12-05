namespace ResumeCraft.Application.Features.Resumes.Models
{
    public class ProjectInputModel
    {
        public Guid? Id { get; set; } = null!;
        public string? Description { get; set; }
        public string? ProjectName { get; set; }
        public string? RepositoryUrl { get; set; }
    }
}
