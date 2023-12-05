using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.ResumeInfo.Sections
{
    public class Reference : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? SupervisorDesignation { get; set; }
        public string? SupervisorEmail { get; set; }
        public string? SupervisorInstituteName { get; set; }
        public string? SupervisorName { get; set; }
        public string? SupervisorPhone { get; set; }

        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}
