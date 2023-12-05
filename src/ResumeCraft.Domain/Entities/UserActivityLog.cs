using ResumeCraft.Domain.Entities.Base;
using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Domain.Entities
{
    public class UserActivityLog : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? UserIp { get; set; }
        public UserOperation Action { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }

        /// User is aggregate root so, DO NOT ADD USER NAVIGATION PROPERTY
    }
}
