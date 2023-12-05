namespace ResumeCraft.Infrastructure.Features.Email.Templates
{
    public partial class ResetPasswordTemplate
    {
        private string Name { get; set; }
        private string Link { get; set; }

        public ResetPasswordTemplate(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }
}
