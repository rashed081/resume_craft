namespace ResumeCraft.Application.Features.CoverLetters.DTOs
{
    public record struct CoverLetterDTO
    {
        public Guid Id { get; set; }
        public string? ApplicantsFullName { get; set; }
        public string? ApplicantsAddresss { get; set; }
        public string? ToWhom { get; set; }
        public string? CompanyAddress { get; set; }
        public string? JobPosition { get; set; }
        public string? LetterContent { get; set; }
        public DateTime? ApplyingDate { get; set; }
    }
}
