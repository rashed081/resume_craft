using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct SkillDTO()
    {
        public Guid Id { get; set; }
        public Guid ResumeId { get; set; }
        public string? Name { get; set; }
        public Level Level { get; set; }
    }
}
