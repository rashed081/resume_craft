using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.ResumeInfo.Sections
{
    public class PersonalDetail : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }
        public Guid ResumeId { get; set; }

        public IList<Social> Socials { get; set; } = new List<Social>();
        public Resume Resume { get; set; } = null!;
    }
}
