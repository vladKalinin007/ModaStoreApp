using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Infrastructure.Data.Config;

public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasMany(cat => cat.Products)
            .WithOne(pr => pr.Category)
            .HasForeignKey(pr => pr.CategoryId);
    }
}