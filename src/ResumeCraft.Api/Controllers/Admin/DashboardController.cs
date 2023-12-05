using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ResumeCraft.Application.Features.Admin.Models;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Api.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILifetimeScope _scope;

        public DashboardController(UserManager<ApplicationUser> userManager, ILifetimeScope scope, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _scope = scope;
            _roleManager = roleManager;
        }

        [HttpGet, Route("data")]
        public async Task<IActionResult> GetDashboardData()
        {
            var model = _scope.Resolve<AdminDashboardModel>();
            model.ResolveDependency(_scope);
            await model.SetTotalTemplateDataAsync();
            model.TotalUser = _userManager.Users.Count();
            return Ok(model);
        }
    }
}
