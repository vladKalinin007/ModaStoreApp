using ModaStore.Domain.Entities.Identity;

namespace ModaStore.Domain.Interfaces.Authentication.Security;

public interface ITokenService
{
    string CreateToken(AppUser user);
}