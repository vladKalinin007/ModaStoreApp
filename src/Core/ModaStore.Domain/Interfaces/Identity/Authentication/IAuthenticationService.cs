using ModaStore.Domain.Entities.Identity;

namespace ModaStore.Domain.Interfaces.Identity.Authentication;

public interface IAuthenticationService
{
    // Task<bool> AuthenticateAsync(string username, string password);
    // Task<bool> LogoutAsync(string username);
    Task<bool> RegisterAsync(AppUser user);
    // Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword);
    // Task<bool> ResetPasswordAsync(string username, string newPassword);
}