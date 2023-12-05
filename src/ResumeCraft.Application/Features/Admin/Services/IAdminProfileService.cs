using ResumeCraft.Domain.Entities;

namespace ResumeCraft.Application.Features.Admin.Services
{
    public interface IAdminProfileService
    {
        Task<Resume> GetEducationsAsync(Guid adminId);
    }
}
