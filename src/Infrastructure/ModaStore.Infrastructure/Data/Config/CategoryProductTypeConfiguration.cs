using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Infrastructure.Data.Config;

public class CategoryProductTypeConfiguration : IEntityTypeConfiguration<CategoryProductType>
{
    public void Configure(EntityTypeBuilder<CategoryProductType> builder)
    {
        builder
            .HasKey(cpt => new {cpt.CategoryId, cpt.ProductTypeId});
        
        builder
            .HasOne(cpt => cpt.Category)
            .WithMany(c => c.CategoryProductTypes)
            .HasForeignKey(cpt => cpt.CategoryId);
        
        builder
            .HasOne(cpt => cpt.ProductType)
            .WithMany(pt => pt.CategoryProductTypes)
            .HasForeignKey(cpt => cpt.ProductTypeId);
    }
}