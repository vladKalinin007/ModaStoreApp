using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Identity;

public class LoginDto 
{
    public string Email { get; set; }
    public string Password { get; set; }
}