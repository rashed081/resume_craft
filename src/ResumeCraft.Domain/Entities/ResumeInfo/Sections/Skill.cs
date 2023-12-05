using ResumeCraft.Domain.Entities.Base;
using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Domain.Entities.ResumeInfo.Sections
{
    public class Skill : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Level? Level { get; set; }

        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}
