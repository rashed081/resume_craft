using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.Resumes.Models
{
    public class EducationInputModel
    {
        public Guid? Id { get; set; } = null!;

        [Required(ErrorMessage = "Organization field can not be empty")]
        public string InstituteName { get; set; } = null!;

        public string? City { get; set; }
        public string? Country { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? Grade { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
