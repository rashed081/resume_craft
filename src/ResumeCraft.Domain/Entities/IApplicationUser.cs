using ResumeCraft.Domain.Entities.Base;
using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Domain.Entities
{
    public interface IApplicationUser : IEntity<Guid>
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
    }
}
