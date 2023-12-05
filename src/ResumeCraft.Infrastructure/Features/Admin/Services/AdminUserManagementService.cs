using ResumeCraft.Application.Features.Admin.DTOs;
using ResumeCraft.Application.Features.Admin.Services;
using ResumeCraft.Application.Services.UnitOfWorks;

namespace ResumeCraft.Infrastructure.Features.Admin.Services
{
    public class AdminUserManagementService : IAdminUserManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public AdminUserManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<UserDTO> users, IDictionary<string, object> outValues)> GetUserListForTableAsync(
            int pageindex,
            int pageSize,
            string searchText,
            string orderBy
        )
        {
            var param = new Dictionary<string, object>();
            param.Add("@Start", pageindex);
            param.Add("@Length", pageSize);
            param.Add("@OrderCol", orderBy);
            param.Add("@Search", searchText);

            var outPutParam = new Dictionary<string, Type>();
            outPutParam.Add("@TotalRecord", typeof(int));
            return await _unitOfWork.Resumes.GetUserForDataTableDynamicAsync(param, outPutParam);
        }
    }
}
