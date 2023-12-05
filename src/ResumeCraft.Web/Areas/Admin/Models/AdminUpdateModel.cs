using ResumeCraft.Domain.Entities.EnumCollections;
using ResumeCraft.Persistence.Features.Account.Membership;
using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Web.Areas.Admin.Models
{
    public class AdminUpdateModel
    {
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z])", ErrorMessage = "The {0} accept A-Z, a-z, ['. -] characters.")]
        [StringLength(100, ErrorMessage = "The {0} take at least {2} and at max {1} characters.", MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z])", ErrorMessage = "The {0} accept A-Z, a-z, ['. -] characters.")]
        [StringLength(100, ErrorMessage = "The {0} take at least {2} and at max {1} characters.", MinimumLength = 2)]
        public string? LastName { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "The {0} is not valid.")]
        [RegularExpression(@"^([01]|\+88)?\d{11}", ErrorMessage = "The {0} is not valid.")]
        public string? PhoneNumber { get; set; }

        public void SetData(ApplicationUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Gender = user.Gender;
            DateOfBirth = user.DateOfBirth;
            PhoneNumber = user.PhoneNumber;
        }
    }
}
