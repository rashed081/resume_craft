using Microsoft.AspNetCore.Mvc;

namespace ResumeCraft.Application.Features.Account.Models
{
    public class ConfirmEmailChangeModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }
    }
}
