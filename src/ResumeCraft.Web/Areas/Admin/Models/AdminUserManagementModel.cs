using Autofac;
using ResumeCraft.Application.Features.Admin.Services;
using ResumeCraft.Domain.Entities.EnumCollections;
using ResumeCraft.Infrastructure.Utilities;

namespace ResumeCraft.Web.Areas.Admin.Models
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
                        user.ImageUrl == null ? "/Admin/assets/media/avatars/blank.png" : $"/upload/userImage/{user.ImageUrl}",
                        user.FirstName,
                        user.LastName,
                        user.Email,
                        user.PhoneNumber,
                        user.DateOfBirth == null ? "N/A" : ((DateTime)user.DateOfBirth).ToString("dd, MMM, yyyy")!,
                        user.Gender == null
                            ? "N/A"
                            : user.Gender == Gender.Male
                                ? "Male"
                                : user.Gender == Gender.Other
                                    ? "Other"
                                    : "Female",
                        user.Id.ToString(),
                    }
                ).ToArray()
            };
        }
    }
}
