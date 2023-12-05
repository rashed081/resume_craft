using Autofac;
using ResumeCraft.Application.Securities;
using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.Account.Models
{
    public class LoginModel
    {
        private ICaptchaService _captchaService;

        public LoginModel() { }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

        [Required]
        public string Recaptcha { get; set; }

        public async Task<bool> IsCaptchaValid()
        {
            return await _captchaService.IsCaptchaValid(Recaptcha);
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _captchaService = scope.Resolve<ICaptchaService>();
        }
    }
}
