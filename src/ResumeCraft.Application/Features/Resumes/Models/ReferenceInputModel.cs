using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.Resumes.Models
{
    public class ReferenceInputModel
    {
        public Guid Id { get; set; }

        public string? SupervisorDesignation { get; set; }
        public string? SupervisorEmail { get; set; }
        public string? SupervisorInstituteName { get; set; }

        [Required(ErrorMessage = ("Name Cannot Be Empty."))]
        public string? SupervisorName { get; set; }
        public string? SupervisorPhone { get; set; }
    }
}
