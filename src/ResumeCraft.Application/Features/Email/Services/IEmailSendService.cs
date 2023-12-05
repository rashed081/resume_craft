namespace ResumeCraft.Application.Features.Email.Services
{
    public interface IEmailSendService
    {
        Task SendPromotionalEmailAsync(string receiverName, string receiverEmail);
        Task SendConfirmEmailAsync(string receiverName, string receiverEmail, string confirmationLink);
        Task SendConfirmEmailAdminAsync(string receiverName, string receiverEmail, string backUrl, string password);
        Task SendResetPasswordEmailAsync(string receiverName, string receiverEmail, string confirmationLink);
    }
}
