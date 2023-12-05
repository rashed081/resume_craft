namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct SocialDTO()
    {
        public Guid Id { get; set; }
        public string? PlatformName { get; set; }
        public string? ProfileUrl { get; set; }
    }
}
