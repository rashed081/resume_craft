using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.ResumeInfo.Sections
{
    public class Project : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? ProjectName { get; set; }
        public string? RepositoryUrl { get; set; }

        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}
