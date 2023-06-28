using System.Security.Claims;

namespace ModaStore.Domain.Interfaces.Identity.Authentication;

public interface ICurrentUserService
{
    public ClaimsPrincipal User { get; }
}
