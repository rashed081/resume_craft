namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct PublicationDTO
    {
        public Guid Id { get; set; }
        public string? InstituteName { get; set; }
        public string? Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? PublishedUrl { get; set; }
    }
}
