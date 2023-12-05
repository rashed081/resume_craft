namespace ResumeCraft.Domain.Services
{
    public interface IHtmlEmailService
    {
        Task SendHtmlEmailAsync(string receiverName, string receiverEmail, string subject, string emailBody);
    }
}
