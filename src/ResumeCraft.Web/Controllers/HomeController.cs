using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResumeCraft.Application.Features.Resumes.DTOs;
using ResumeCraft.Web.Models;
using System.Diagnostics;

namespace ResumeCraft.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult TermsOfUses()
        {
            return View("TermsOfUses");
        }

        public async Task<IActionResult> Dashboard()
        {
            Guid userId = new Guid("36d8860d-2857-49e3-9213-08dbcda23071");
            try
            {
                string apiUrl = $"{userId}/resumes/";

                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    List<ResumeDTO> resumes = JsonConvert.DeserializeObject<List<ResumeDTO>>(responseContent);

                    return View(resumes);
                }
                else
                {
                    List<ResumeDTO> resumes = new List<ResumeDTO>();
                    return View(resumes);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                throw new Exception($"An error occurred: {ex.Message}");
            }


        }

        #region Utility Action

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        #endregion
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
