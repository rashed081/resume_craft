using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.CoverLetterInfo
{
    public class CoverLetterTemplate : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? TemplateName { get; set; }
        public string? Path { get; set; }
    }
}
