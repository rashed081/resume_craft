using ResumeCraft.Application.Features.Admin.DTOs;

namespace ResumeCraft.Application.Features.Admin.Services
{
    public interface IAdminUserManagementService
    {
        Task<(IList<UserDTO> users, IDictionary<string, object> outValues)> GetUserListForTableAsync(
            int pageindex,
            int pageSize,
            string searchText,
            string orderBy
        );
    }
}
