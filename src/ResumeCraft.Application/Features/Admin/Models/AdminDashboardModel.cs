using Autofac;
using ResumeCraft.Application.Features.Admin.Services;

namespace ResumeCraft.Application.Features.Admin.Models
{
    public class AdminDashboardModel
    {
        private IAdminDashboardService _adminDashboardService;
        public int TotalUser { get; set; }
        public int TotalTemplete { get; set; }

        public AdminDashboardModel() { }

        public void ResolveDependency(ILifetimeScope scope)
        {
            try
            {
                _adminDashboardService = scope.Resolve<IAdminDashboardService>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SetTotalTemplateDataAsync()
        {
            TotalTemplete = await _adminDashboardService.GetResumeCountAsync();
        }
    }
}
