using Microsoft.AspNetCore.Mvc;

namespace ResumeCraft.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly HttpClient _client;
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient("Resumecraft");
        }
    }
}
