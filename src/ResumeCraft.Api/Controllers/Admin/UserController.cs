using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using ResumeCraft.Application.Features.Account.Models;
using ResumeCraft.Application.Features.Email.Services;
using ResumeCraft.Persistence.Features.Account.Membership;
using System.Security.Claims;
using System.Text;

namespace ResumeCraft.Api.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly IEmailSendService _emailSendService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IEmailSendService emailSendService,
            ILifetimeScope lifetimeScope
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt.");
                return BadRequest(model);
            }

            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.Phone,
                DateOfBirth = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var role = await _roleManager.FindByNameAsync("Admin");
                if (role == null)
                {
                    role = new ApplicationRole { Name = "Admin" };
                    await _roleManager.CreateAsync(role);
                }
                await _userManager.AddToRoleAsync(user, role.Name!);
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName), new Claim(ClaimTypes.Role, "Admin") };
                await _userManager.AddClaimsAsync(user, claims);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                var callbackUrl = $"{Request.Scheme}://{Request.Host}/Account/ConfirmEmail?userId={user.Id}&token={token}";

                await _emailSendService.SendConfirmEmailAdminAsync(user.FirstName, user.Email, callbackUrl, model.Password);
                model.RegistrationConfirmUrl = callbackUrl;
                return Ok(true);
            }

            foreach (var error in result.Errors)
            {
                return BadRequest(error);
            }

            return StatusCode(400);
        }
    }
}
