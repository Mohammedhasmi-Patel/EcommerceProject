
using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class DiscountProductConfiguration : IEntityTypeConfiguration<DiscountProduct>
    {
        public void Configure(EntityTypeBuilder<DiscountProduct> builder)
        {
            builder.ToTable("DiscountProducts");
            builder.HasKey(dp => dp.Id);

            builder.Property(dp => dp.Id);
            builder.HasIndex(dp => dp.DiscountId);
            builder.HasIndex(dp => dp.ProductId);

            builder.HasOne(dp => dp.Discount)
                   .WithMany(d => d.DiscountProducts)
                   .HasForeignKey(dp => dp.DiscountId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dp => dp.Product)
                   .WithMany(p => p.DiscountProducts)
                   .HasForeignKey(dp => dp.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}