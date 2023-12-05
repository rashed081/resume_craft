namespace ResumeCraft.Infrastructure.Features.Email.Templates
{
    public partial class PromotionalEmailTemplate
    {
        private string Name { get; set; }

        public PromotionalEmailTemplate(string name)
        {
            Name = name;
        }
    }
}
