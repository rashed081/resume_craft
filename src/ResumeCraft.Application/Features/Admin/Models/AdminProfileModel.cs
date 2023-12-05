using Autofac;
using ResumeCraft.Application.Features.Admin.Services;
using ResumeCraft.Domain.Entities;
using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Application.Features.Admin.Models
{
    public class AdminProfileModel
    {
        private IAdminProfileService _adminProfileService;

        public AdminProfileModel() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Resume Resume { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }

        public void ResolveDependecy(ILifetimeScope scope)
        {
            _adminProfileService = scope.Resolve<IAdminProfileService>();
        }

        public async Task GetAdminProfileDataAsync(Guid adminId)
        {
            Resume = await _adminProfileService.GetEducationsAsync(adminId);
        }
    }
}
