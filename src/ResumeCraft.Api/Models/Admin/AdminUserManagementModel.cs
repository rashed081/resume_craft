using Autofac;
using ResumeCraft.Application.Features.Admin.Services;
using ResumeCraft.Domain.Entities.EnumCollections;
using ResumeCraft.Infrastructure.Utilities;

namespace ResumeCraft.Api.Models.Admin
{
    public class AdminUserManagementModel
    {
        private IAdminUserManagementService _adminUserManagementService;

        public AdminUserManagementModel() { }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _adminUserManagementService = scope.Resolve<IAdminUserManagementService>();
        }

        public async Task<object> GetPagedUserAsync(DataTableAjaxUtitlites dataTableAjaxUtitlites)
        {
            var dataSet = await _adminUserManagementService.GetUserListForTableAsync(
                dataTableAjaxUtitlites.PageIndex,
                dataTableAjaxUtitlites.PageSize,
                dataTableAjaxUtitlites.SearchText,
                dataTableAjaxUtitlites.GetSortText(new string[] { "", "FirstName", "LastName", "Email", "PhoneNumber", "DateOfBirth" })
            );
            return new
            {
                recordsTotal = (int)dataSet.outValues["@TotalRecord"],
                recordsFiltered = (int)dataSet.outValues["@TotalRecord"],
                data = (
                    from user in dataSet.users
                    select new string[]
                    {
                        user.ImageUrl == null ? "/Admin/assets/media/avatars/blank.png" : user.ImageUrl,
                        user.FirstName,
                        user.LastName,
                        user.Email,
                        user.PhoneNumber,
                        user.DateOfBirth == null ? "N/A" : user.DateOfBirth.ToString()!,
                        user.Gender == null
                            ? "N/A"
                            : user.Gender == Gender.Male
                                ? "Male"
                                : "Female",
                        user.Id.ToString(),
                    }
                ).ToArray()
            };
        }
    }
}
