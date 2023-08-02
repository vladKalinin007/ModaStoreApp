using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Infrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        
        // product brand
        builder
            .HasOne(product => product.ProductBrand)
            .WithMany(x => x.Products)
            .HasForeignKey(p => p.ProductBrandId);
        
        // product type
        builder
            .HasOne(product => product.ProductType)
            .WithMany(x => x.Products)
            .HasForeignKey(product => product.ProductTypeId);

        // One to many

        // reviews +
        builder
            .HasMany(pr => pr.ProductReviews)
            .WithOne(rev => rev.Product)
            .HasForeignKey(rev => rev.ProductId);
        
        // related products +
        builder
            .HasMany(pr => pr.RelatedProducts)
            .WithOne(rel => rel.Product)
            .HasForeignKey(pr => pr.ProductId)
            .HasPrincipalKey(p => p.Id);
                
        // Many to many ----------------------------------------------------------------
        
        // pictures
        builder
            .HasMany(pr => pr.Pictures)
            .WithMany(pic => pic.Products)
            .UsingEntity<ProductPicture>(
                
                j => j
                    .HasOne(pt => pt.Picture)
                    .WithMany(t => t.ProductPictures)
                    .HasForeignKey(pt => pt.PictureId),
                
                j => j
                    .HasOne(pt => pt.Product)
                    .WithMany(p => p.ProductPictures)
                    .HasForeignKey(pt => pt.ProductId),
                
                j =>
                {
                    j.HasKey(t => new {t.ProductId, t.PictureId});
                }
            );
        
        // tags
        builder
            .HasMany(Product => Product.Tags)
            .WithMany(Tag => Tag.Products)
            .UsingEntity<ProductTag>(
                
                j => j
                    .HasOne(pt => pt.Tag)
                    .WithMany(t => t.ProductTags)
                    .HasForeignKey(pt => pt.TagId),
                
                j => j
                    .HasOne(pt => pt.Product)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(pt => pt.ProductId),
                
                j =>
                {
                    j.HasKey(t => new {t.ProductId, t.TagId});
                }
            );
        
        // sizes
        builder
            .HasMany(pr => pr.Sizes)
            .WithMany(sz => sz.Products)
            .UsingEntity<ProductSize>(
                
                j => j
                    .HasOne(pt => pt.Size)
                    .WithMany(t => t.ProductSizes)
                    .HasForeignKey(pt => pt.SizeId),
                
                j => j
                    .HasOne(pt => pt.Product)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(pt => pt.ProductId),
                
                j =>
                {
                    j.HasKey(t => new {t.ProductId, t.SizeId});
                }
            );
        
        // colors
        builder
            .HasMany(product => product.Colors)
            .WithMany(color => color.Products)
            .UsingEntity<ProductColor>(
                
                j => j
                    .HasOne(pt => pt.Color)
                    .WithMany(t => t.ProductColors)
                    .HasForeignKey(pt => pt.ColorId),
                
                j => j
                    .HasOne(pt => pt.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(pt => pt.ProductId),
                
                j =>
                {
                    j.HasKey(t => new {t.ProductId, t.ColorId});
                }
            );
    }
}