namespace ResumeCraft.Application.Features.Resumes.Models
{
    public class PersonalDetailInputModel
    {
        public Guid? Id { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }

        public List<SocialInputModel> Socials { get; } = new();
    }
}
