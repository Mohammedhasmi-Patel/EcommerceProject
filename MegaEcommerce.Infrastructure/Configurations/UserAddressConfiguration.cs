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

            builder.Property(ua => ua.City)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(ua => ua.State)
                   .IsRequired()
                   .HasMaxLength(100);


            builder.Property(ua => ua.Country)
                   .IsRequired()
                   .HasMaxLength(100);


            // Indexes
            builder.HasIndex(ua => ua.UserId);
            builder.HasIndex(ua => ua.IsDefault);

            builder.HasOne(ua => ua.User)
                   .WithMany(u => u.UserAddresses)
                   .HasForeignKey(ua => ua.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}