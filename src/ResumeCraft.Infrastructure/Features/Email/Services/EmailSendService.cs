using ResumeCraft.Application.Features.Email.Services;
using ResumeCraft.Domain.Services;
using ResumeCraft.Infrastructure.Features.Email.Templates;

namespace ResumeCraft.Infrastructure.Features.Email.Services
{
    public class EmailSendService : IEmailSendService
    {
        private readonly IHtmlEmailService _emailService;

        public EmailSendService(IHtmlEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SendPromotionalEmailAsync(string receiverName, string receiverEmail)
        {
            string subject = "Promotional Email";
            var template = new PromotionalEmailTemplate(receiverName);
            string emailBody = template.TransformText();

            await _emailService.SendHtmlEmailAsync(receiverName, receiverEmail, subject, emailBody);
        }

        public async Task SendConfirmEmailAsync(string receiverName, string receiverEmail, string backUrl)
        {
            string subject = "Email Confirmation";
            var template = new EmailConfirmationTemplate(receiverName, backUrl);
            string emailBody = template.TransformText();

            await _emailService.SendHtmlEmailAsync(receiverName, receiverEmail, subject, emailBody);
        }

        public async Task SendResetPasswordEmailAsync(string receiverName, string receiverEmail, string backUrl)
        {
            string subject = "Reset Password";
            var template = new ResetPasswordTemplate(receiverName, backUrl);
            string emailBody = template.TransformText();

            await _emailService.SendHtmlEmailAsync(receiverName, receiverEmail, subject, emailBody);
        }

        public async Task SendConfirmEmailAdminAsync(string receiverName, string receiverEmail, string backUrl, string password)
        {
            string subject = "Email Confirmation";
            var template = new AdminRegistrationConfirmationTemplate(receiverName, backUrl, password);
            string emailBody = template.TransformText();

            await _emailService.SendHtmlEmailAsync(receiverName, receiverEmail, subject, emailBody);
        }
    }
}
