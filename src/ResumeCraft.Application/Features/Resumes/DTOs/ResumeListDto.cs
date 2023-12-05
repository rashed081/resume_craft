namespace ResumeCraft.Application.Features.Resumes.DTOs
{
    public record struct ResumeListDto()
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
