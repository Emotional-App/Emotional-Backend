using System.Security.Claims;

namespace Emotional.Common.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken Create(string userId);
        ClaimsPrincipal ValidateToken(string token);
    }
}
