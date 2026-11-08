using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.CartService.Domain.Entities;

namespace OnlineShop.CartService.Infrastructure.Persistence.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> modelBuilder)
    {
        modelBuilder.ToTable("cart_items");
        modelBuilder.HasKey(x => x.Id);

        modelBuilder.Property(x => x.ProductName)
            .HasMaxLength(300)
            .IsRequired();

        modelBuilder.Property(x => x.UnitPrice)
            .HasPrecision(18, 2);

        modelBuilder.Property(x => x.Quantity)
            .IsRequired();
    }
}