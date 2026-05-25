using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MegaEcommerce.Infrastructure.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                    .HasMaxLength(300)
                    .IsRequired();

            builder.Property(x => x.Latitude)
                        .HasMaxLength(50)
                        .IsRequired();

            builder.Property(x => x.Longitude)
                        .HasMaxLength(50)
                        .IsRequired();


            builder.HasOne(c => c.State)
                    .WithMany(s => s.Cities)
                    .HasForeignKey(c => c.StateId);
        }
    }
}
