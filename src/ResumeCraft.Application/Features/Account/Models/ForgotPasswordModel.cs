using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.Account.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? CallBackUrl { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }
    }
}
