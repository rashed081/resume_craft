using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.ResumeInfo.Sections
{
    public class Certification : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? InstituteName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Title { get; set; }

        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}
