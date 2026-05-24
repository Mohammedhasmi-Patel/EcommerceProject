using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(pi => pi.AltText)
                   .HasMaxLength(500);

            builder.Property(pi => pi.DisplayOrder)
                   .IsRequired();

            builder.Property(pi => pi.IsPrimary)
                   .HasDefaultValue(false);

            builder.Property(pi => pi.CreatedAt)
                   .IsRequired();

            builder.HasIndex(pi => pi.ProductId);

            builder.HasOne(pi => pi.Product)
                   .WithMany(p => p.ProductImages)
                   .HasForeignKey(pi => pi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}