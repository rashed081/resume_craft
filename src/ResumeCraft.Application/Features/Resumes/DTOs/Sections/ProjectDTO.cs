namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct ProjectDTO()
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? ProjectName { get; set; }
        public string? RepositoryUrl { get; set; }
    }
}
