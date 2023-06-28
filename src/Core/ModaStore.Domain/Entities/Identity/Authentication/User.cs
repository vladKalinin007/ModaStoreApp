using Microsoft.AspNetCore.Identity;

namespace ModaStore.Domain.Entities.Identity.Authentication;

public class User : IdentityUser
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsLockedOut { get; set; }
}