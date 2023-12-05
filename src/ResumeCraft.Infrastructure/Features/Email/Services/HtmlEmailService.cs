using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using ResumeCraft.Domain.Entities.Email;
using ResumeCraft.Domain.Services;

namespace ResumeCraft.Infrastructure.Features.Email.Services
{
    public class HtmlEmailService : IHtmlEmailService
    {
        private readonly Smtp _smtp;

        public HtmlEmailService(IOptions<Smtp> smtpSettings)
        {
            _smtp = smtpSettings.Value;
        }

        public async Task SendHtmlEmailAsync(string receiverName, string receiverEmail, string subject, string htmlBody)
        {
            var message = new MimeMessage { Subject = subject };
            message.From.Add(new MailboxAddress(_smtp.SenderName, _smtp.SenderEmail));
            message.To.Add(new MailboxAddress(receiverName, receiverEmail));

            var builder = new BodyBuilder { HtmlBody = htmlBody };
            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            {
                client.Connect(_smtp.Host, _smtp.Port, SecureSocketOptions.StartTls);
                client.Timeout = 30000;

                await client.AuthenticateAsync(_smtp.Username, _smtp.Password);
                await client.SendAsync(message);

                client.Disconnect(true);
            }
        }
    }
}
