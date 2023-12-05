using ResumeCraft.Application.Features.Email.Services;
using ResumeCraft.Persistence.Features.Email.Services.Skeleton;

namespace ResumeCraft.EmailWorker
{
    public class EmailSender
    {
        public EmailSender() { }

        private readonly IEmailUserService _userService;
        private readonly IEmailSendService _emailService;

        public EmailSender(IEmailUserService userService, IEmailSendService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        public async Task SendPromotionalEmail()
        {
            var users = _userService.GetUsers().ToList();
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    var userName = $"{user.FirstName} {user.LastName}";
                    await _emailService.SendPromotionalEmailAsync(userName, user.Email);
                }
            }
        }
    }
}
