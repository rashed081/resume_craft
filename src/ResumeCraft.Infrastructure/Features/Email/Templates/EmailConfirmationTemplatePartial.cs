namespace ResumeCraft.Infrastructure.Features.Email.Templates
{
    public partial class EmailConfirmationTemplate
    {
        private string Name { get; set; }
        private string Link { get; set; }

        public EmailConfirmationTemplate(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }
}
