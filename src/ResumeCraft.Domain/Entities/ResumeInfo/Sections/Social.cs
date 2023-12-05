using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.ResumeInfo.Sections
{
    public class Social : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? PlatformName { get; set; }
        public string? ProfileUrl { get; set; }

        public Guid PersonalDetailId { get; set; }
        public PersonalDetail PersonalDetail { get; set; } = null!;
    }
}
