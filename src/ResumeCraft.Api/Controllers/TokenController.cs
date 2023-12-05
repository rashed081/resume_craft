using Microsoft.AspNetCore.Identity;
using ResumeCraft.Application.Securities;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Api.Controllers
{
    [ApiController]
    [Route("v3/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TokenController(
            IConfiguration config,
            ITokenService tokenService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _configuration = config;
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email, string password)
        {
            if (email == null || password == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByEmailAsync(email);
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, true);

            if (result != null && result.Succeeded)
            {
                var claims = (await _userManager.GetClaimsAsync(user)).ToArray();
                var token = await _tokenService.GetJwtToken(claims);

                return Ok(token);
            }
            else
            {
                return BadRequest("Invalid credentials provided.");
            }
        }
    }
}
