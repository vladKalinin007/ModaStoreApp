using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModaStore.Domain.Entities.Identity;

namespace ModaStore.Application.Extensions;

public static class UserManagerExtensions
{
    public static async Task<AppUser> FindByEmaiWithAdressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email);
        return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
    }
    
    public static async Task<AppUser> FindByEmailFromClaimsPrincipal(this UserManager<AppUser> input, ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email);
        return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
    }
} 