using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.ResumeInfo.Sections
{
    public class Experience : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Designation { get; set; }
        public string? Achievement { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}
