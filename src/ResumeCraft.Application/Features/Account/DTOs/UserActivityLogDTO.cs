using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Application.Features.Account.DTOs
{
    public record struct UserActivityLogDTO()
    {
        public DateTime Date { get; set; }
        public string? UserIp { get; set; }
        public UserOperation Action { get; set; }
        public string? Description { get; set; }
    }
}
