using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discounts");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(d => d.CouponCode)
                   .HasMaxLength(100);

            builder.Property(d => d.DiscountType)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(d => d.DiscountValue)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(d => d.MaximumDiscountAmount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(d => d.StartsAt)
                   .IsRequired();

            builder.Property(d => d.ExpiresAt)
                   .IsRequired();

            builder.Property(d => d.IsActive)
                   .HasDefaultValue(true);

            // Indexes
            builder.HasIndex(d => d.CouponCode);
            builder.HasIndex(d => d.IsActive);
            // Relationships
            builder.HasMany(d => d.DiscountProducts)
                   .WithOne(dp => dp.Discount)
                   .HasForeignKey(dp => dp.DiscountId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}