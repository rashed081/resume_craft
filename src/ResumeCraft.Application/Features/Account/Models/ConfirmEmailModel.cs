using Microsoft.AspNetCore.Mvc;

namespace ResumeCraft.Application.Features.Account.Models
{
    public class ConfirmEmailModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }
    }
}
