// namespace ModaStore.Infrastructure.Data.Models;
//
// public partial class StoreContext : DbContext
// {
//     public StoreContext()
//     {
//     }
//
//     public StoreContext(DbContextOptions<StoreContext> options)
//         : base(options)
//     {
//     }
//
//     public virtual DbSet<Address> Addresses { get; set; }
//
//     public virtual DbSet<AppUser> AppUsers { get; set; }
//
//     public virtual DbSet<Category> Categories { get; set; }
//
//     public virtual DbSet<Color> Colors { get; set; }
//
//     public virtual DbSet<Comment> Comments { get; set; }
//
//     public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; }
//
//     public virtual DbSet<Order> Orders { get; set; }
//
//     public virtual DbSet<OrderItem> OrderItems { get; set; }
//
//     public virtual DbSet<Picture> Pictures { get; set; }
//
//     public virtual DbSet<Product> Products { get; set; }
//
//     public virtual DbSet<ProductBrand> ProductBrands { get; set; }
//
//     public virtual DbSet<ProductCategory> ProductCategories { get; set; }
//
//     public virtual DbSet<ProductColor> ProductColors { get; set; }
//
//     public virtual DbSet<ProductPicture> ProductPictures { get; set; }
//
//     public virtual DbSet<ProductSize> ProductSizes { get; set; }
//
//     public virtual DbSet<ProductTag> ProductTags { get; set; }
//
//     public virtual DbSet<ProductType> ProductTypes { get; set; }
//
//     public virtual DbSet<RelatedProduct> RelatedProducts { get; set; }
//
//     public virtual DbSet<Size> Sizes { get; set; }
//
//     public virtual DbSet<Tag> Tags { get; set; }
//
//     public virtual DbSet<UserField> UserFields { get; set; }
//
//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=API;User Id=Kali;Password=12345OHdf%e;MultipleActiveResultSets=True;TrustServerCertificate=true;");
//
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Address>(entity =>
//         {
//             entity.HasIndex(e => e.AppUserId, "IX_Addresses_AppUserId").IsUnique();
//
//             entity.HasOne(d => d.AppUser).WithOne(p => p.Address)
//                 .HasForeignKey<Address>(d => d.AppUserId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//         });
//
//         modelBuilder.Entity<AppUser>(entity =>
//         {
//             entity.ToTable("AppUser");
//         });
//
//         modelBuilder.Entity<Category>(entity =>
//         {
//             entity.Property(e => e.ShowOnHomePage).HasDefaultValueSql("(CONVERT([bit],(0)))");
//         });
//
//         modelBuilder.Entity<Comment>(entity =>
//         {
//             entity
//                 .HasIndex(e => e.AppUserId, "IX_Comments_AppUserId");
//         
//             entity
//                 .HasIndex(e => e.ProductId, "IX_Comments_ProductId");
//         
//             entity
//                 .HasOne(d => d.AppUser)
//                 .WithMany(p => p.Comments)
//                 .HasForeignKey(d => d.AppUserId);
//         
//             entity
//                 .HasOne(d => d.Product)
//                 .WithMany(p => p.Comments)
//                 .HasForeignKey(d => d.ProductId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//         });
//
//         modelBuilder.Entity<DeliveryMethod>(entity =>
//         {
//             entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
//         });
//
//         modelBuilder.Entity<Order>(entity =>
//         {
//             entity.HasIndex(e => e.DeliveryMethodId, "IX_Orders_DeliveryMethodId");
//         
//             entity.HasIndex(e => e.ShipToAddressId, "IX_Orders_ShipToAddressId");
//         
//             entity.Property(e => e.ShipToAddressId).HasDefaultValueSql("(N'')");
//             entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
//         
//             entity.HasOne(d => d.DeliveryMethod).WithMany(p => p.Orders).HasForeignKey(d => d.DeliveryMethodId);
//         
//             entity.HasOne(d => d.ShipToAddress).WithMany(p => p.Orders)
//                 .HasForeignKey(d => d.ShipToAddressId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//         });
//
//         modelBuilder.Entity<OrderItem>(entity =>
//         {
//             entity.HasIndex(e => e.OrderId, "IX_OrderItems_OrderId");
//         
//             entity.Property(e => e.ItemOrderedPictureUrl).HasColumnName("ItemOrdered_PictureUrl");
//             entity.Property(e => e.ItemOrderedProductItemId).HasColumnName("ItemOrdered_ProductItemId");
//             entity.Property(e => e.ItemOrderedProductName).HasColumnName("ItemOrdered_ProductName");
//             entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
//         
//             entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
//                 .HasForeignKey(d => d.OrderId)
//                 .OnDelete(DeleteBehavior.Cascade);
//         });
//
//         modelBuilder.Entity<Product>(entity =>
//         {
//             entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");
//
//             entity.HasIndex(e => e.ProductBrandId, "IX_Products_ProductBrandId");
//
//             entity.HasIndex(e => e.ProductTypeId, "IX_Products_ProductTypeId");
//
//             entity
//                 .HasOne(d => d.Category)
//                 .WithMany(p => p.Products)
//                 .HasForeignKey(d => d.CategoryId);
//
//             entity
//                 .HasOne(d => d.ProductBrand)
//                 .WithMany(p => p.Products)
//                 .HasForeignKey(d => d.ProductBrandId)
//                 .OnDelete(DeleteBehavior.Cascade);
//
//             entity
//                 .HasOne(d => d.ProductType)
//                 .WithMany(p => p.Products)
//                 .HasForeignKey(d => d.ProductTypeId)
//                 .OnDelete(DeleteBehavior.Cascade);
//         });
//
//         modelBuilder.Entity<ProductBrand>(entity =>
//         {
//             entity.Property(e => e.Description).HasDefaultValueSql("(N'')");
//             entity.Property(e => e.PictureUrl).HasDefaultValueSql("(N'')");
//         });
//
//
//         modelBuilder.Entity<ProductColor>(entity =>
//         {
//             entity.HasKey(e => new { e.ProductId, e.ColorId });
//
//             entity.HasIndex(e => e.ColorId, "IX_ProductColors_ColorId");
//
//             entity.HasOne(d => d.Color).WithMany(p => p.ProductColors)
//                 .HasForeignKey(d => d.ColorId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//
//             entity.HasOne(d => d.Product).WithMany(p => p.ProductColors)
//                 .HasForeignKey(d => d.ProductId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//         });
//
//         modelBuilder.Entity<ProductPicture>(entity =>
//         {
//             entity.HasKey(e => new { e.ProductId, e.PictureId });
//
//             entity.HasIndex(e => e.PictureId, "IX_ProductPictures_PictureId");
//
//             entity.HasOne(d => d.Picture).WithMany(p => p.ProductPictures)
//                 .HasForeignKey(d => d.PictureId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//
//             entity.HasOne(d => d.Product).WithMany(p => p.ProductPictures)
//                 .HasForeignKey(d => d.ProductId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//         });
//
//         modelBuilder.Entity<ProductSize>(entity =>
//         {
//             entity.HasKey(e => new { e.ProductId, e.SizeId });
//
//             entity.HasIndex(e => e.SizeId, "IX_ProductSizes_SizeId");
//
//             entity.HasOne(d => d.Product).WithMany(p => p.ProductSizes)
//                 .HasForeignKey(d => d.ProductId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//
//             entity.HasOne(d => d.Size).WithMany(p => p.ProductSizes)
//                 .HasForeignKey(d => d.SizeId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//         });
//
//         modelBuilder.Entity<ProductTag>(entity =>
//         {
//             entity.HasKey(e => new { e.ProductId, e.TagId });
//
//             entity.HasIndex(e => e.TagId, "IX_ProductTags_TagId");
//
//             entity.HasOne(d => d.Product).WithMany(p => p.ProductTags)
//                 .HasForeignKey(d => d.ProductId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//
//             entity.HasOne(d => d.Tag).WithMany(p => p.ProductTags)
//                 .HasForeignKey(d => d.TagId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//         });
//
//         modelBuilder.Entity<ProductType>(entity =>
//         {
//             entity.Property(e => e.Description).HasDefaultValueSql("(N'')");
//         });
//
//         modelBuilder.Entity<RelatedProduct>(entity =>
//         {
//             entity.HasIndex(e => e.ProductId, "IX_RelatedProducts_ProductId");
//         
//             entity.HasIndex(e => e.RelatedProductId, "IX_RelatedProducts_RelatedProductId");
//         
//             entity
//                 .HasOne(d => d.Product)
//                 .WithMany(p => p.RelatedProductProducts)
//                 .HasForeignKey(d => d.ProductId)
//                 .OnDelete(DeleteBehavior.ClientSetNull);
//         
//             // entity
//             //     .HasOne(d => d.RelatedProductNavigation)
//             //     .WithMany(p => p.RelatedProductRelatedProductNavigations)
//             //     .HasForeignKey(d => d.RelatedProductId)
//             //     .OnDelete(DeleteBehavior.ClientSetNull);
//         });
//         
//         modelBuilder.Entity<UserField>(entity =>
//         {
//             entity
//                 .HasNoKey()
//                 .ToTable("UserField");
//         });
//         
//         OnModelCreatingPartial(modelBuilder);
//     }
//
//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
// }
