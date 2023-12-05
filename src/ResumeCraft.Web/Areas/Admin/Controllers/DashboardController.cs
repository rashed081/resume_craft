using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResumeCraft.Application.Features.Admin.Models;
using ResumeCraft.Infrastructure.Utilities;
using ResumeCraft.Web.Areas.Admin.Models;
using ResumeCraft.Web.Controllers;

namespace ResumeCraft.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin")]
    public class DashboardController : BaseController
    {
        private readonly ILifetimeScope _scope;

        public DashboardController(IHttpClientFactory httpClientFactory, ILifetimeScope scope)
            : base(httpClientFactory)
        {
            _scope = scope;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Active = "index";
            //SetTokentHeader();
            var response = await _client.GetAsync("/api/v1/admin/dashboard/data");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<AdminDashboardModel>(content);
                return View(data);
            }
            return View(null);
        }

        public IActionResult UserManagement()
        {
            ViewBag.Active = "user";
            return View();
        }

        public async Task<IActionResult> GetUserList()
        {
            var ajaxUtilites = new DataTableAjaxUtitlites(Request);
            var model = _scope.Resolve<AdminUserManagementModel>();
            model.ResolveDependency(_scope);
            var data = await model.GetPagedUserAsync(ajaxUtilites);
            return Json(data);
        }
    }
}
