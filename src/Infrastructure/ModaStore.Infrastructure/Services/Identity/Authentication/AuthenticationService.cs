using Microsoft.EntityFrameworkCore;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Data;
using ModaStore.Domain.Interfaces.Identity.Authentication;
using ModaStore.Infrastructure.Data;

namespace ModaStore.Infrastructure.Services.Identity.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly StoreContext _context;
    
    public AuthenticationService(StoreContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterAsync(AppUser user)
    {
        var result = await _context.AppUsers.AddAsync(user);
        await _context.SaveChangesAsync();
        return result.State == EntityState.Added;
    }
    
}