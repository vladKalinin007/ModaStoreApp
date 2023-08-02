

using ModaStore.Domain.Common;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Order.OrderManagement;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ModaStore.Domain.Entities.Content;
using ModaStore.Domain.Entities.Identity;


namespace ModaStore.Infrastructure.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
        
    }
    
    public DbSet<Address> Addresses { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductPicture> ProductPictures { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<RelatedProducts> RelatedProducts { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}