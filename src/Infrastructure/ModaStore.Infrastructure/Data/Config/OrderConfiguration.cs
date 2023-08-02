using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModaStore.Domain.Entities.Order.OrderManagement;
using OrderEntity = ModaStore.Domain.Entities.Order.OrderManagement.Order;


namespace ModaStore.Infrastructure.Data.Config;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        // builder.OwnsOne(o => o.ShipToAddress, a =>
        // {
        //     a.WithOwner();
        // });

        builder.Property(s => s.Status)
            .HasConversion(
                o => o.ToString(),
                o => (OrderStatus) Enum.Parse(typeof(OrderStatus), o)
            );

        builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade); 
    }
}