using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.CoverLetterInfo
{
    public class CoverLetter : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? ToWhom { get; set; }
        public string? CompanyAddress { get; set; }
        public string? JobPosition { get; set; }
        public string? LetterContent { get; set; }
        public DateTime? ApplyingDate { get; set; }
        public string? ApplicantsFullName { get; set; }
        public string? ApplicantsAddresss { get; set; }

        public Guid UserId { get; set; }
        public Guid CoverLetterTemplateId { get; set; }
    }
}
