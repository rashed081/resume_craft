using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.Resumes.Models
{
    public class AwardInputModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Field Cannot be empty.")]
        public string? InstituteName { get; set; }

        [Required(ErrorMessage = "Title Cannot be empty.")]
        public string? Title { get; set; }
    }
}
