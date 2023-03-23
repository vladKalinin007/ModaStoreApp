using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
    
}

// dotnet ef migrations add <MigrationName>
// dotnet ef database update
// dotnet ef database -h
// dotnet if -h 
