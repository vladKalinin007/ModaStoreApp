using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModaStore.Domain.Models.OrderAggregate;

namespace ModaStore.Infrastructure.Data.Config;

public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
{
    public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
    {
        builder.Property(d => d.Price)
            .HasColumnType("decimal(18,2)");
        
    }
}