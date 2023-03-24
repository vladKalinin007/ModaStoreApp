using System.Reflection;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
}

// dotnet ef migrations add <MigrationName>
// dotnet ef migrations remove -p Infrastructure -s API
// dotnet ef database update
// dotnet ef database drop -p Infrastructure -s API
// dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations
    

// dotnet ef database -h
// dotnet if -h 
