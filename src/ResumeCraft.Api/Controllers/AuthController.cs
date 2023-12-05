namespace ResumeCraft.Api.Controllers
{
    public class AuthController : ApiController
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [Route("Test")]
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}
