using Autofac;
using ResumeCraft.Application.Securities;
using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.Account.Models
{
    public class RegisterModel
    {
        private ICaptchaService _captchaService;

        public RegisterModel() { }

        [Required]
        [Display(Name = "First Name")]
        // https://regexr.com/7lhfc
        [RegularExpression(@"^[a-zA-Z ]+(['\. -]|[a-zA-Z ])*$", ErrorMessage = "The {0} accept A-Z, a-z, ['. -] characters.")]
        [StringLength(100, ErrorMessage = "The {0} take at least {2} and at max {1} characters.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        // https://regexr.com/7lhfc
        [RegularExpression(@"^[a-zA-Z ]+(['\. -]|[a-zA-Z ])*$", ErrorMessage = "The {0} accept A-Z, a-z, ['. -] characters.")]
        [StringLength(100, ErrorMessage = "The {0} take at least {2} and at max {1} characters.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "The {0} is not valid.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "The {0} is not valid.")]
        //[RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "The {0} is not valid.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        // https://regexr.com/7m6dj
        [Phone(ErrorMessage = "The {0} is not valid.")]
        [RegularExpression(@"^((01)|(\+8801))\d{9}$", ErrorMessage = "The {0} is not valid.")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must accept at least {2} characters or more.", MinimumLength = 8)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Recaptcha { get; set; }

        public string? ReturnUrl { get; set; }

        public string? RegistrationConfirmUrl { get; set; }

        public void RelsolveDependency(ILifetimeScope scope)
        {
            _captchaService = scope.Resolve<ICaptchaService>();
        }

        public async Task<bool> IsCaptchaValid()
        {
            return await _captchaService.IsCaptchaValid(Recaptcha);
        }
    }
}
