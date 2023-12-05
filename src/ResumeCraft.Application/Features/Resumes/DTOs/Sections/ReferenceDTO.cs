namespace ResumeCraft.Application.Features.Resumes.DTOs.Sections
{
    public record struct ReferenceDTO
    {
        public Guid Id { get; set; }
        public string? SupervisorDesignation { get; set; }
        public string? SupervisorEmail { get; set; }
        public string? SupervisorInstituteName { get; set; }
        public string? SupervisorName { get; set; }
        public string? SupervisorPhone { get; set; }
    }
}
