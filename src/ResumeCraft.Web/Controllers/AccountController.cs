using Autofac;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ResumeCraft.Application.Features.Account.Models;
using ResumeCraft.Application.Securities;
using ResumeCraft.Persistence.Features.Account.Membership;
using ResumeCraft.Web.Models;
using System.Net;

namespace ResumeCraft.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(
            ILifetimeScope scope,
            ILogger<AccountController> logger,
            IHttpClientFactory httpClientFactory,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            ITokenService tokenService
        )
            : base(httpClientFactory)
        {
            _scope = scope;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        #region Register

        public IActionResult RegisterAsync(string returnUrl = null)
        {
            var model = _scope.Resolve<RegisterModel>();
            model.ReturnUrl = returnUrl;

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            model.ReturnUrl ??= Url.Action("Login", "Account");
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "Invalid register attempt.");
                return View(model);
            }

            model.RelsolveDependency(_scope);
            if (!await model.IsCaptchaValid())
            {
                return LocalRedirect(model.ReturnUrl);
            }

            var request = await _client.PostAsJsonAsync("Account/Register", model);

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<bool>(content);
                if (data)
                    return LocalRedirect($"/account/confirmEmailMessage?userName={model.FirstName} " + $"{model.LastName}&email={model.Email}");
            }

            ModelState.AddModelError(string.Empty, $"Error: {request.ReasonPhrase}");
            return View(model);
        }

        #endregion

        #region Login & Logout

        public async Task<IActionResult> LoginAsync(string returnUrl = null)
        {
            var model = _scope.Resolve<LoginModel>();
            model.ReturnUrl = returnUrl;

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            model.ReturnUrl ??= "~/Admin/Dashboard/Index";
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                if (!await model.IsCaptchaValid())
                {
                    ModelState.AddModelError("", "Captcha is not valid");
                    return View(model);
                }
                var request = await _client.PostAsJsonAsync("Account/Login", model);

                if (request.StatusCode == HttpStatusCode.OK)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        var role = (await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(model.Email))).FirstOrDefault();
                        if (role == "User")
                            //add user dashboard
                            model.ReturnUrl = "/";
                        var content = await request.Content.ReadAsStringAsync();
                        HttpContext.Session.SetString("token", content!);
                        return LocalRedirect(model.ReturnUrl);
                    }
                }
                else if (request.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ModelState.AddModelError("", "Email is not confirmed yet.");
                    return View(model);
                }
                else if (request.StatusCode.ToString() == "321")
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> LogoutAsync(string returnUrl = null)
        {
            var model = _scope.Resolve<LogoutModel>();
            model.ReturnUrl = returnUrl;

            await _client.PostAsJsonAsync("Account/Logout", model);
            await _signInManager.SignOutAsync();
            return returnUrl != null ? Redirect(model.ReturnUrl) : RedirectToAction("Index", "Home");
        }

        #endregion

        #region ChangePassword

        [Authorize(Roles = "User, Admin")]
        public IActionResult ChangePassword()
        {
            var model = _scope.Resolve<ChangePasswordModel>();
            return View(model);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            //SetTokentHeader();
            model.Email = User.Identity?.Name!;
            var request = await _client.PostAsJsonAsync("Account/ChangePassword", model);
            if (request.IsSuccessStatusCode)
            {
                model.StatusMessage = "Your password has been changed";
                return View(model);
            }
            ModelState.AddModelError(string.Empty, $"Error: {request.ReasonPhrase}");

            return View(model);
        }

        #endregion

        #region ForgotPassword

        public IActionResult ForgotPasswordAsync()
        {
            var model = _scope.Resolve<ForgotPasswordModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            model.CallBackUrl = $"{Request.Scheme}://{Request.Host}{Url.Action("ResetPassword", "Account")}";

            var request = await _client.PostAsJsonAsync("Account/ForgotPassword", model);
            model.StatusMessage = request.IsSuccessStatusCode ? "Please check your email to reset password." : $"Error: {request.ReasonPhrase}";

            return View(model);
        }

        #endregion

        #region Reset Password

        public async Task<IActionResult> ResetPasswordAsync(string userId = null, string token = null)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            var model = _scope.Resolve<ResetPasswordModel>();
            model.Token = token;
            model.Email = user.Email;

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            var request = await _client.PostAsJsonAsync("Account/ResetPassword", model);
            if (request.IsSuccessStatusCode)
            {
                model.StatusMessage = "Your account password has been reset.";
                return View(model);
            }
            ModelState.AddModelError(string.Empty, $"Error: {request.ReasonPhrase}");

            return View(model);
        }

        #endregion

        #region ManageAppEmail

        [Authorize]
        public IActionResult ChangeEmailAsync()
        {
            var model = _scope.Resolve<ChangeEmailModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeEmailAsync(ChangeEmailModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            model.CallBackUrl = $"{Request.Scheme}://{Request.Host}{Url.Action("ConfirmEmailChange", "Account")}";

            var request = await _client.PostAsJsonAsync("Account/ChangeEmail", model);
            model.StatusMessage = request.IsSuccessStatusCode
                ? "Please check your email to confirm email change."
                : $"Error! {request.ReasonPhrase}.";

            return View(model);
        }

        public async Task<IActionResult> ConfirmEmailAsync(string userId = null, string token = null)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            var model = _scope.Resolve<ConfirmEmailModel>();
            model.UserId = userId;
            model.Token = token;

            var request = await _client.PostAsJsonAsync("Account/ConfirmEmail", model);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id.Equals(new Guid(userId)));
            if (user == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            var confirmModel = new ConfirmEmaiMessageModel { Name = user.FirstName + " " + user.LastName, Email = user.Email };
            confirmModel.HasErrorInEmailConfiramtion = !request.IsSuccessStatusCode;
            return View(confirmModel);
        }

        public async Task<IActionResult> ConfirmEmailChangeAsync(string userId, string email, string token)
        {
            if (userId == null || email == null || token == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<ConfirmEmailChangeModel>();
            model.UserId = userId;
            model.Email = email;
            model.Token = token;

            var request = await _client.PostAsJsonAsync("Account/ConfirmEmailChange", model);
            model.StatusMessage = request.IsSuccessStatusCode ? "Thank you for confirmed your email change." : "Error! changing your email.";

            return View(model);
        }

        public IActionResult ConfirmEmailMessage(string userName, string email)
        {
            var model = new ConfirmEmaiMessageModel { Name = userName, Email = email };
            return View(model);
        }

        #endregion
    }
}
