namespace ResumeCraft.Application.Features.Resumes.Models
{
    public class SocialInputModel
    {
        public Guid? Id { get; set; } = null!;

        public string? PlatformName { get; set; }
        public string? ProfileUrl { get; set; }
    }
}
