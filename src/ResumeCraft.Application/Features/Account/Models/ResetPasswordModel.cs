using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.Account.Models
{
    public class ResetPasswordModel
    {
        public string Token { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must accept at least {2} characters or more.", MinimumLength = 8)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }
    }
}
