using ResumeCraft.Application.Features.Admin.DTOs;
using ResumeCraft.Domain.Entities;
using ResumeCraft.Domain.Repositories;

namespace ResumeCraft.Application.Features.Resumes.Repositories
{
    public interface IResumeRepository : IRepositoryBase<Resume, Guid>
    {
        Task<Resume> GetResumeWithRelatedData(Guid resumeId);

        Task<(IList<UserDTO> users, IDictionary<string, object> outValues)>
            GetUserForDataTableDynamicAsync(IDictionary<string, object> parameters, IDictionary<string, Type> outParameters);

        Task<Resume?> GetResumeWithRelatedDataByUserAsync(Guid userId);
    }
}
