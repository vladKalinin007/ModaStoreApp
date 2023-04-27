using System.Reflection;
using Core.Models;
using Core.Models.OrderAggregate;
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
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

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
// dotnet ef migrations add OrderEntityAdded -p Infrastructure -s API -o Data/Migrations
// dotnet ef migrations add OrderEntityAdded -p Infrastructure -s API -o Data/Migrations -c StoreContext

// dotnet ef database update -p Infrastructure -s API --context StoreContext
// dotnet ef database -h
// dotnet if -h 
