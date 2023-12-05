namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct PersonalDetailsDTO()
    {
        public Guid Id { get; set; }
        public readonly string? FullName
        {
            get => FirstName + " " + LastName;
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }
        public IList<SocialDTO> Socials { get; set; } = new List<SocialDTO>();
    }
}
