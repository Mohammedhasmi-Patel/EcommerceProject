using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class OrderAddressConfiguration : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.ToTable("OrderAddresses");
            builder.HasKey(oa => oa.Id);

            builder.Property(oa => oa.RecipientName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(oa => oa.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(oa => oa.Landmark)
                   .HasMaxLength(500);

            builder.Property(oa => oa.CountryName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(oa => oa.StateName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(oa => oa.CityName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(oa => oa.AddressLine1)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(oa => oa.AddressLine2)
                   .HasMaxLength(500);

            builder.Property(oa => oa.ZipCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(oa => oa.OrderId);

            builder.HasOne(oa => oa.Order)
                   .WithOne(o => o.OrderAddress)
                   .HasForeignKey<OrderAddress>(oa => oa.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}