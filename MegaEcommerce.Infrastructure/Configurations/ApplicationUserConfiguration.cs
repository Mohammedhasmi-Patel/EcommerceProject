using MegaEcommerce.Domain.Entities;
using MegaEcommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.ProfileUrl).HasMaxLength(250);
            builder.Property(u => u.RefreshToken).HasMaxLength(500);
            builder.Property(u => u.Role).HasConversion<int>().IsRequired();
            builder.Property(u => u.TokenExpiredTime).IsRequired();

            builder.HasIndex(u => u.NormalizedUserName)
                   .HasDatabaseName("IX_Users_NormalizedUserName")
                   .IsUnique();

            builder.HasIndex(u => u.NormalizedEmail)
                   .HasDatabaseName("IX_Users_NormalizedEmail");

            builder.HasMany(u => u.Products)
                   .WithOne(p => p.CreatedByUser)
                   .HasForeignKey(p => p.CreatedBy)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Categories)
                   .WithOne(c => c.CreatedByUser)
                   .HasForeignKey(c => c.CreatedBy)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CartItems)
                   .WithOne(ci => ci.User)
                   .HasForeignKey(ci => ci.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Orders)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Reviews)
                   .WithOne(r => r.User)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Transactions)
                   .WithOne()
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserAddresses)
                   .WithOne(ua => ua.User)
                   .HasForeignKey(ua => ua.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}