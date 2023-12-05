using ResumeCraft.Application.Features.Resumes.DTOs;
using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Application.Features.Account.DTOs
{
    public record struct ApplicationUserDTO()
    {
        public string? FullName
        {
            get => FirstName + " " + LastName;
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public IList<ResumeDTO> Resumes { get; set; } = new List<ResumeDTO>();
        public IList<UserActivityLogDTO> UserActivities { get; set; } = new List<UserActivityLogDTO>();
    }
}
