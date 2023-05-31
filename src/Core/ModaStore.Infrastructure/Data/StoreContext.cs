using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ModaStore.Domain.Common;
using ModaStore.Domain.Models;
using ModaStore.Domain.Models.Catalog;
using ModaStore.Domain.Models.OrderAggregate;
// using ModaStore.API.Dto.Catalog;
using NewCategory = ModaStore.Domain.Catalog.Category;

namespace ModaStore.Infrastructure.Data;

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
    public DbSet<Category> Categories { get; set; }
    public DbSet<NewCategory> NewCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<UserField>().HasNoKey();
        }
}

// dotnet ef migrations add <MigrationName>
// dotnet ef migrations remove -p ModaStore.Infrastructure -s ModaStore.API
// dotnet ef database update
// dotnet ef database drop -p ModaStore.Infrastructure -s ModaStore.API
// dotnet ef migrations add OrderEntityAdded -p ModaStore.Infrastructure -s ModaStore.API -o Data/Migrations
// dotnet ef migrations add NCategoryEntityAdded -p ModaStore.Infrastructure -s ModaStore.API -o Data/Migrations -c StoreContext
// dotnet ef migrations remove -p ModaStore.Infrastructure -s ModaStore.API -c StoreContext

// dotnet ef database update -p ModaStore.Infrastructure -s ModaStore.API --context StoreContext
// dotnet ef database -h
// dotnet if -h 
