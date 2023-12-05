using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResumeCraft.Application.Features.Admin.Models;
using ResumeCraft.Persistence.Features.Account.Membership;
using ResumeCraft.Web.Areas.Admin.Models;
using ResumeCraft.Web.Controllers;
using ResumeCraft.Web.Models;
using ResumeCraft.Web.Utilities;

namespace ResumeCraft.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILifetimeScope _scope;

        public ProfileController(IHttpClientFactory httpClient, UserManager<ApplicationUser> userManager, ILifetimeScope scope)
            : base(httpClient)
        {
            _userManager = userManager;
            _scope = scope;
        }

        public async Task<IActionResult> MyProfile()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            //SetTokentHeader();
            var baseUrl = $"/api/v1/admin/profile/getAdmin?id={user.Id}";
            var response = await _client.GetAsync(baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<AdminProfileModel>(content);
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.DateOfBirth = user.DateOfBirth;
                model.ImageUrl = user.ImageUrl;
                model.Gender = user.Gender;
                model.PhoneNumber = user.PhoneNumber;
                model.Email = user.Email;
                return View(model);
            }
            return LocalRedirect("/admin/dashboard");
        }

        public async Task<IActionResult> SaveImage(IFormFile file)
        {
            try
            {
                var imageDir = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/userImage"));
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                if (user.ImageUrl != null)
                {
                    var prvPath = Path.Combine(imageDir, user.ImageUrl);

                    if (System.IO.File.Exists(prvPath))
                    {
                        System.IO.File.Delete(prvPath);
                    }
                }

                using (var img = Image.Load(file.OpenReadStream()))
                {
                    var imageUrl = Guid.NewGuid() + "_" + DateTime.Now.Ticks.ToString() + ".jpg";
                    var fullPath = Path.Combine(imageDir, imageUrl);

                    img.Mutate(x => x.Resize(300, 300));
                    img.SaveAsJpeg(fullPath);
                    user.ImageUrl = imageUrl;
                    await _userManager.UpdateAsync(user);
                }
                return Json("success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity?.Name!);
            var model = _scope.Resolve<AdminUpdateModel>();
            model.SetData(user);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminUpdateModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var appUser = await _userManager.FindByEmailAsync(User.Identity?.Name!);
                    appUser.FirstName = user.FirstName;
                    appUser.LastName = user.LastName;
                    appUser.PhoneNumber = user.PhoneNumber;
                    appUser.Gender = user.Gender;
                    appUser.DateOfBirth = user.DateOfBirth;
                    await _userManager.UpdateAsync(appUser);
                    TempData.Put<ResponseModel>(
                        "ResponseMessage",
                        new ResponseModel
                        {
                            Title = "Success",
                            Message = "Successfully updated.",
                            Type = ResponseTypes.Success
                        }
                    );
                }
                else
                {
                    return View(user);
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
            return LocalRedirect("/admin/profile/myProfile");
        }
    }
}
