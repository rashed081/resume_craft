using Autofac;
using Microsoft.AspNetCore.Mvc;
using ResumeCraft.Application.Features.CoverLetters.Models;

namespace ResumeCraft.Web.Controllers
{
    public class CoverLetterController : BaseController
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<AccountController> _logger;

        public CoverLetterController(ILifetimeScope scope, ILogger<AccountController> logger, IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
            _scope = scope;
            _logger = logger;
        }

        public IActionResult CoverLetterCreate()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CoverLetterCreate(CoverLetterInputModel model)
        {
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "Invalid  Data.");
                return View(model);
            }
            var request = await _client.PostAsJsonAsync("CoverLetter/CoverLetterCreate", model);
            if (request.IsSuccessStatusCode)
            {
                return View(model);
            }
            return View("CoverLetterCreate");
        }
    }
}
