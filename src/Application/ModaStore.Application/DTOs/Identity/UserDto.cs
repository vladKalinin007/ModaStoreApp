using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Identity;

public class UserDto : BaseDto
{
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string Token { get; set; }
}