using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Entities.Order.OrderManagement;

namespace ModaStore.Infrastructure.Data.Config;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder
            .HasOne(u => u.Address)  // Указываем связь один-к-одному
            .WithOne(a => a.AppUser) // Указываем обратную связь один-к-одному
            .HasForeignKey<Address>(a => a.AppUserId); // Указываем внешний ключ
    }
}