using System.Security.Claims;

namespace ResumeCraft.Application.Securities
{
    public interface ITokenService
    {
        Task<string> GetJwtToken(IList<Claim> claims);
    }
}
