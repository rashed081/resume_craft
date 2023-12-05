using ResumeCraft.Domain.Entities.Base;
using ResumeCraft.Domain.Entities.ResumeInfo.Sections;
using ResumeCraft.Domain.Utilities;

namespace ResumeCraft.Domain.Entities
{
    public class Resume : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } =
            CustomRegex.Replace(
                CustomRegex.TemplateName,
                string.Format("Resume_{0}_{1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()).ToString(),
                "_"
            ); // Resume_9_25_2023_11_22_36_AM
        public bool IsDeleted { get; set; } = false;
        public Guid? ResumeTemplateId { get; set; }
        public Guid UserId { get; set; }

        public PersonalDetail? PersonalDetail { get; set; } = null!;
        public Summary? Summary { get; set; } = null!;
        public IList<Award> Awards { get; set; } = new List<Award>();
        public IList<Certification> Certifications { get; set; } = new List<Certification>();
        public IList<CurricularActivity> CurricularActivities { get; set; } = new List<CurricularActivity>();
        public IList<Education> Educations { get; set; } = new List<Education>();
        public IList<Experience> Experiences { get; set; } = new List<Experience>();
        public IList<Interest> Interests { get; set; } = new List<Interest>();
        public IList<Project> Projects { get; set; } = new List<Project>();
        public IList<Publication> Publications { get; set; } = new List<Publication>();
        public IList<Reference> References { get; set; } = new List<Reference>();
        public IList<Skill> Skills { get; set; } = new List<Skill>();

        /// User is aggregate root so, DO NOT ADD USER NAVIGATION PROPERTY
    }
}
