using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.ResumeInfo.Sections
{
    public class Education : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? Grade { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InstituteName { get; set; } = null!;

        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}
