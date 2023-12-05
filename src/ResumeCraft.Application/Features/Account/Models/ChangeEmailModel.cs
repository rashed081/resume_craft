using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.Account.Models
{
    public class ChangeEmailModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "New Email")]
        public string NewEmail { get; set; }

        public string? CallBackUrl { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }
    }
}
