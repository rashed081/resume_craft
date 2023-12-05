namespace ResumeCraft.Application.Features.Admin.Services
{
    public interface IAdminDashboardService
    {
        Task<int> GetResumeCountAsync();
    }
}
