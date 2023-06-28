using System.Security.Claims;

namespace ModaStore.Domain.Interfaces.Identity.Authentication;

public interface ITokenProvider
{
    string GenerateToken(string userId, IEnumerable<string> roles);
    bool ValidateToken(string token);
    ClaimsPrincipal GetPrincipalFromToken(string token);
    Task<string> RefreshToken(string token);
}
