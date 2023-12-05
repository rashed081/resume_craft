using ResumeCraft.Application.Features.Resumes.DTOs.Sections;

namespace ResumeCraft.Application.Features.Resumes.DTOs
{
    public record struct ResumeDTO()
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public Guid? SelectedTemplateId { get; set; }
        public PersonalDetailsDTO? Contact { get; set; }
        public SummaryDTO? Summary { get; set; }
        public IList<AwardDTO> Awards { get; set; } = new List<AwardDTO>();
        public IList<CertificationDTO> Certifications { get; set; } = new List<CertificationDTO>();
        public IList<CurricularActivityDTO> CurricularActivities { get; set; } = new List<CurricularActivityDTO>();
        public IList<EducationDTO> Educations { get; set; } = new List<EducationDTO>();
        public IList<ExperienceDTO> Experiences { get; set; } = new List<ExperienceDTO>();
        public IList<InterestDTO> Interests { get; set; } = new List<InterestDTO>();
        public IList<ProjectDTO> Projects { get; set; } = new List<ProjectDTO>();
        public IList<PublicationDTO> Publications { get; set; } = new List<PublicationDTO>();
        public IList<ReferenceDTO> References { get; set; } = new List<ReferenceDTO>();
        public IList<SkillDTO> Skills { get; set; } = new List<SkillDTO>();
    }
}
