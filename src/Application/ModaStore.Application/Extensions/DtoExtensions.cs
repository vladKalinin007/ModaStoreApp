using ModaStore.Application.DTOs.Identity;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Authentication.Security;
using ModaStore.Infrastructure.Services.Authentication.Security;

namespace ModaStore.Application.Extensions;

public static class DtoExtensions
{
    
    public static UserDto AddToken(this UserDto userDto, ITokenService tokenService, AppUser user)
    {
        string token = tokenService.CreateToken(user);
        userDto.Token = token;
        return userDto;
    }
}