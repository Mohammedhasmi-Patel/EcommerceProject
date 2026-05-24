using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Slug)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(p => p.ShortDescription)
                   .HasMaxLength(500);

            builder.Property(p => p.Description)
                   .HasMaxLength(4000);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.StrikethroughPrice)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.StockQuantity)
                   .IsRequired();

            builder.Property(p => p.IsFeatured)
                   .HasDefaultValue(false);

            builder.Property(p => p.IsPublished)
                   .HasDefaultValue(true);

            // Indexes
            builder.HasIndex(p => p.Slug);
            builder.HasIndex(p => p.CategoryId);
            builder.HasIndex(p => p.CreatedBy);

            // Relationships
            builder.HasOne(p => p.Category)
                   .WithMany()
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.CreatedByUser)
                   .WithMany(u => u.Products)
                   .HasForeignKey(p => p.CreatedBy)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
