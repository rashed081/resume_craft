using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResumeCraft.Application.Features.Account.Models;
using ResumeCraft.Persistence.Features.Account.Membership;
using ResumeCraft.Web.Controllers;
using ResumeCraft.Web.Models;
using ResumeCraft.Web.Utilities;

namespace ResumeCraft.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly ILifetimeScope _scope;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(
            ILifetimeScope scope,
            IHttpClientFactory httpClientFactory,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
            : base(httpClientFactory)
        {
            _scope = scope;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Add()
        {
            var model = _scope.Resolve<RegisterModel>();
            ViewBag.Active = "user";
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RegisterModel model)
        {
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "Invalid register attempt.");
                return View(model);
            }

            var request = await _client.PostAsJsonAsync("/api/v1/admin/user/register", model);

            if (request.IsSuccessStatusCode)
            {
                try
                {
                    var content = await request.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<bool>(content);
                    if (data)
                    {
                        TempData.Put<ResponseModel>(
                            "ResponseMessage",
                            new ResponseModel
                            {
                                Title = "Success",
                                Message = "Successfully added an admin. This admin should cofirm his/her email for login.",
                                Type = ResponseTypes.Success
                            }
                        );
                        return LocalRedirect($"/admin/dashboard/userManagement");
                    }
                }
                catch (Exception ex)
                {
                    TempData.Put<ResponseModel>(
                        "ResponseMessage",
                        new ResponseModel
                        {
                            Title = "Error",
                            Message = ex.Message,
                            Type = ResponseTypes.Danger
                        }
                    );
                }
            }
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (User.Identity.Name != user.UserName)
                {
                    await _userManager.DeleteAsync(user!);
                    TempData.Put<ResponseModel>(
                        "ResponseMessage",
                        new ResponseModel
                        {
                            Title = "Success",
                            Type = ResponseTypes.Success,
                            Message = $"Data of {user!.FirstName} {user.LastName} has been removed."
                        }
                    );
                }
                else
                {
                    TempData.Put<ResponseModel>(
                        "ResponseMessage",
                        new ResponseModel
                        {
                            Title = "Error",
                            Type = ResponseTypes.Danger,
                            Message = $"You cannot delete your information from this table."
                        }
                    );
                }
                return LocalRedirect("/admin/dashboard/userManagement");
            }
            catch (Exception ex)
            {
                TempData.Put<ResponseModel>(
                    "ResponseMessage",
                    new ResponseModel
                    {
                        Title = "Error",
                        Type = ResponseTypes.Danger,
                        Message = ex.Message
                    }
                );
                return LocalRedirect("/admin/dashboard/userManagement");
            }
        }
    }
}
