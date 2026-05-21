using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddresses");

            // Current model uses UserId as the key (see domain model).
            // Keep existing key to match current model; consider changing the domain model
            // to use a dedicated Id GUID for proper one-to-many mapping.
            builder.HasKey(ua => ua.UserId);

            builder.Property(ua => ua.RecipientName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(ua => ua.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(ua => ua.Landmark)
                   .HasMaxLength(250);

            builder.Property(ua => ua.AddressLine1)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(ua => ua.AddressLine2)
                   .HasMaxLength(500);

            builder.Property(ua => ua.ZipCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(ua => ua.IsDefault)
                   .HasDefaultValue(false);

            // Indexes
            builder.HasIndex(ua => ua.UserId).HasDatabaseName("IX_UserAddresses_UserId");
            builder.HasIndex(ua => ua.IsDefault).HasDatabaseName("IX_UserAddresses_IsDefault");

            // Relationships
            // UserAddress.UserId -> ApplicationUser.Id
            builder.HasOne(ua => ua.User)
                   .WithMany(u => u.UserAddresses)
                   .HasForeignKey(ua => ua.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Country / State / City are configured as reference lookups.
            // These entities do not declare a collection of UserAddress, so configure as WithMany() without navigation.
            builder.HasOne(ua => ua.Country)
                   .WithMany()
                   .HasForeignKey(ua => ua.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ua => ua.State)
                   .WithMany()
                   .HasForeignKey(ua => ua.StateId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ua => ua.City)
                   .WithMany()
                   .HasForeignKey(ua => ua.CityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}