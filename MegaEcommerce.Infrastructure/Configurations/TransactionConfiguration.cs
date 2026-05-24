using MegaEcommerce.Domain.Entities;
using MegaEcommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaEcommerce.Infrastructure.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.TransactionId)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(t => t.Order)
                    .WithMany(o => o.Transactions)
                    .HasForeignKey(t => t.OrderId);


            builder.Property(t => t.Gateway)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.PaymentMethod)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(t => t.Amount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(t => t.Status)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(t => t.GatewayResponse)
                   .HasMaxLength(4000);

            builder.HasIndex(t => t.UserId);
            builder.HasIndex(t => t.OrderId);


            builder.HasOne(t => t.User)
                   .WithMany(u => u.Transactions)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}