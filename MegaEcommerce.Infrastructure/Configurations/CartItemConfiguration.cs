using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");

            // Composite primary key: one cart entry per user-product pair
            builder.HasKey(ci => new { ci.UserId, ci.ProductId });

            // Properties
            builder.Property(ci => ci.Quantity)
                   .IsRequired();

            builder.Property(ci => ci.UnitPrice)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(ci => ci.DiscountAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(ci => ci.SubTotal)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(ci => ci.CreatedAt)
                   .IsRequired();

            builder.Property(ci => ci.UpdatedAt);

            builder.Property(ci => ci.LastSyncedAt)
                   .IsRequired();

            // Indexes
            builder.HasIndex(ci => ci.UserId).HasDatabaseName("IX_CartItems_UserId");
            builder.HasIndex(ci => ci.ProductId).HasDatabaseName("IX_CartItems_ProductId");

            // Relationships
            builder.HasOne(ci => ci.User)
                   .WithMany(u => u.CartItems)
                   .HasForeignKey(ci => ci.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Product)
                   .WithMany(p => p.CartItems)
                   .HasForeignKey(ci => ci.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}