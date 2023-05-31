using ModaStore.Domain.Models.Identity;

namespace ModaStore.Domain.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}