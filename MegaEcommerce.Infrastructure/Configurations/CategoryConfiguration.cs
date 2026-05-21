
using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Slug)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Icon)
                   .HasMaxLength(250);

            builder.Property(c => c.Description)
                   .HasMaxLength(1000);

            builder.Property(c => c.IsFeatured)
                   .HasDefaultValue(false);

            builder.Property(c => c.CreatedBy)
                   .IsRequired();

            // Indexes
            builder.HasIndex(c => c.Slug)
                   .HasDatabaseName("IX_Categories_Slug")
                   .IsUnique();

            builder.HasIndex(c => c.CreatedBy)
                   .HasDatabaseName("IX_Categories_CreatedBy");

            builder.HasIndex(c => c.IsFeatured)
                   .HasDatabaseName("IX_Categories_IsFeatured");

            // Self-referencing relationship: ParentCategory -> SubCategories
            builder.HasOne(c => c.ParentCategory)
                   .WithMany(p => p.SubCategories)
                   .HasForeignKey(c => c.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CreatedBy -> ApplicationUser
            builder.HasOne(c => c.CreatedByUser)
                   .WithMany(u => u.Categories)
                   .HasForeignKey(c => c.CreatedBy)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}