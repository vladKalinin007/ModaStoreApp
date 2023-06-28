using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModaStore.Domain.Entities.Identity;

namespace ModaStore.Infrastructure.Identity;

public class AppIdentityDbContext : IdentityDbContext<AppUser>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
    
}

// dotnet ef migrations add <migration> -p ModaStore.Infrastructure -s ModaStore.API -o Identity/Migrations
// dotnet ef database update -p ModaStore.Infrastructure -s ModaStore.API --context AppIdentityDbContext
