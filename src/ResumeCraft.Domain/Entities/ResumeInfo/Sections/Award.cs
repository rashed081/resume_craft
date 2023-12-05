using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.ResumeInfo.Sections
{
    public class Award : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? InstituteName { get; set; }
        public string? Title { get; set; }

        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}
