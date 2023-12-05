using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Application.Features.Admin.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public Gender Gender { get; set; }
    }
}
