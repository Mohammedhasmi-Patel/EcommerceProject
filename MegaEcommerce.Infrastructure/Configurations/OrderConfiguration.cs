using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderNumber)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(o => o.TotalPrice)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(o => o.ShippingFees)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasIndex(o => o.UserId);
            builder.HasIndex(o => o.OrderNumber);

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.OrderAddress)
                   .WithOne(oa => oa.Order)
                   .HasForeignKey<OrderAddress>(oa => oa.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.Transactions)
                    .WithOne(o => o.Order)
                    .HasForeignKey(t => t.OrderId)
                    .OnDelete(DeleteBehavior.NoAction);

            // Note: Order.Transactions exists in the model but Transaction has no OrderId FK.
            // Keep transaction mapping at Transaction configuration or add OrderId to Transaction model.
        }
    }
}