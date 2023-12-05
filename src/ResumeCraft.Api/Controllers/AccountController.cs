using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using ResumeCraft.Application.Features.Account.Models;
using ResumeCraft.Application.Features.Email.Services;
using ResumeCraft.Application.Securities;
using ResumeCraft.Persistence.Features.Account.Membership;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ResumeCraft.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSendService _emailMessageService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ITokenService _tokenService;

        public AccountController(
            ILifetimeScope scope,
            ILogger<AccountController> logger,
            IEmailSendService emailMessageService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            ITokenService tokenService
        )
        {
            _scope = scope;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailMessageService = emailMessageService;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        #region Register

        [HttpPost, Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            model.ReturnUrl ??= Url.Action("Login", "Account");
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
                var role = await _roleManager.FindByNameAsync("User");
                if (role == null)
                {
                    role = new ApplicationRole { Name = "User" };
                    await _roleManager.CreateAsync(role);
                }
                await _userManager.AddToRoleAsync(user, role.Name!);
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName), new Claim(ClaimTypes.Role, "User") };
                await _userManager.AddClaimsAsync(user, claims);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                var callbackUrl =
                    $"{Request.Scheme}://{"localhost:7176"}/Account/ConfirmEmail?userId={WebUtility.UrlEncode(user.Id.ToString())}&token={WebUtility.UrlEncode(token)}";

                await _emailMessageService.SendConfirmEmailAsync(user.FirstName, user.Email, callbackUrl);
                model.RegistrationConfirmUrl = callbackUrl;
                return Ok(true);
            }

            foreach (var error in result.Errors)
            {
                return BadRequest(error);
            }

            return StatusCode(400);
        }

        #endregion

        #region Login & Logout

        [HttpPost, Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                        return StatusCode(321);
                    var claims = (await _userManager.GetClaimsAsync(user)).ToArray();
                    var token = await _tokenService.GetJwtToken(claims);
                    return Ok(token);
                }
                else
                {
                    // Username or password is incorrect.
                    return StatusCode(401);
                }
            }

            return BadRequest();
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }

        #endregion

        #region ChangePassword

        [Authorize(Roles = "Admin, User")]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordModel model)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(400);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return StatusCode(401);
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest();
            }
            return StatusCode(200);
        }

        #endregion

        #region ForgotPassword

        [HttpPost, Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordModel model)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(400);
            }

            var isLogin = await _userManager.GetUserAsync(User);
            if (isLogin != null)
            {
                return StatusCode(401);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return StatusCode(401);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var callbackUrl = $"{model.CallBackUrl}?userId={WebUtility.UrlEncode(user.Id.ToString())}&token={WebUtility.UrlEncode(token)}";

            await _emailMessageService.SendResetPasswordEmailAsync(user.FullName, model.Email, callbackUrl);

            return StatusCode(200);
        }

        #endregion

        #region Reset Password

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordModel model)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(400);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return StatusCode(404);
            }

            model.Token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Token));
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            return result.Succeeded ? StatusCode(200) : StatusCode(406);
        }

        #endregion

        #region ManageAppEmail

        [HttpPost, Route("ChangeEmail")]
        public async Task<IActionResult> ChangeEmailAsync([FromBody] ChangeEmailModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return StatusCode(401);
            }

            var isConfirmEmail = await _userManager.IsEmailConfirmedAsync(user);
            if (isConfirmEmail == false)
            {
                return StatusCode(406);
            }

            var currentEmail = await _userManager.GetEmailAsync(user);
            if (model.NewEmail == currentEmail)
            {
                return StatusCode(400);
            }

            var token = await _userManager.GenerateChangeEmailTokenAsync(user, model.NewEmail);
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            var userId = await _userManager.GetUserIdAsync(user);
            var callbackUrl =
                $"{model.CallBackUrl}?userId={WebUtility.UrlEncode(userId)}&email={WebUtility.UrlEncode(model.NewEmail)}&token={WebUtility.UrlEncode(token)}";
            await _emailMessageService.SendConfirmEmailAsync(user.FirstName, model.NewEmail, callbackUrl);

            return StatusCode(200);
        }

        [HttpPost, Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmailAsync([FromBody] ConfirmEmailModel model)
        {
            if (model.UserId == null || model.Token == null)
            {
                return StatusCode(404);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return StatusCode(404);
            }

            model.Token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Token));
            var result = await _userManager.ConfirmEmailAsync(user, model.Token);
            if (result.Succeeded)
            {
                return StatusCode(200);
            }

            return StatusCode(400);
        }

        [HttpPost, Route("ConfirmEmailChange")]
        public async Task<IActionResult> ConfirmEmailChangeAsync([FromBody] ConfirmEmailChangeModel model)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(203);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return StatusCode(404);
            }

            model.Token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Token));
            var changeEmail = await _userManager.ChangeEmailAsync(user, model.Email, model.Token);
            if (changeEmail.Succeeded == false)
            {
                return StatusCode(400);
            }

            var setUsername = await _userManager.SetUserNameAsync(user, model.Email);
            if (setUsername.Succeeded == false)
            {
                return StatusCode(400);
            }

            await _signInManager.RefreshSignInAsync(user);
            return StatusCode(200);
        }

        #endregion
    }
}
