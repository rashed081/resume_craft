using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.Resumes.Models
{
    public class PublicationInputModel
    {
        public Guid? Id { get; set; } = null!;

        [Required(ErrorMessage = "Organization field can not be empty")]
        public string InstituteName { get; set; } = null!;
        public string? Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? PublishedUrl { get; set; }
    }
}
