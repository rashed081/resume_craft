using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ResumeCraft.Application.Features.Admin.Models;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Api.Controllers.Admin
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProfileController : ControllerBase
    {
        private readonly ILifetimeScope _lifetimeScope;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(ILifetimeScope scope, UserManager<ApplicationUser> userManager)
        {
            _lifetimeScope = scope;
            _userManager = userManager;
        }

        [HttpGet, Route("getAdmin")]
        public async Task<IActionResult> GetProfileDataAsync(Guid id)
        {
            try
            {
                var model = _lifetimeScope.Resolve<AdminProfileModel>();
                model.ResolveDependecy(_lifetimeScope);
                await model.GetAdminProfileDataAsync(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
