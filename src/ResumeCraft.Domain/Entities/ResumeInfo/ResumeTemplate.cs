using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.ResumeInfo
{
    public class ResumeTemplate : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? TemplateName { get; set; }
        public string? Path { get; set; }
    }
}
