namespace ResumeCraft.Infrastructure.Features.Email.Templates
{
    public partial class AdminRegistrationConfirmationTemplate
    {
        private string Name { get; set; }
        private string Url { get; set; }
        private string Password { get; set; }

        public AdminRegistrationConfirmationTemplate(string name, string url, string password)
        {
            Name = name;
            Url = url;
            Password = password;
        }
    }
}
