using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MegaEcommerce.Infrastructure.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {

            /*
             * public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Iso3 { get; set; } = null!;


        public string Iso2 { get; set; } = null!;
        public string Capital { get; set; } = null!;
        public string Currency { get; set; } = null!;

        public string Region { get; set; } = null!;
        public string Subregion { get; set; } = null!;

        public long? Population { get; set; }
             * 
             */
            builder.ToTable("Countries");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(300)
                   .IsRequired();


            builder.Property(x => x.Iso3)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(x => x.Iso2)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(x => x.Capital)
                   .HasMaxLength(100)
                   .IsRequired();;

            builder.Property(x => x.Currency)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.Region)
                   .HasMaxLength(50)
                   .IsRequired();


            builder.Property(x => x.Subregion)
                   .HasMaxLength(50)
                   .IsRequired();


            builder.Property(x => x.Population);
                    
            builder.HasIndex(x => x.Iso2)
                   .IsUnique();

            builder.HasIndex(x => x.Iso3)
                   .IsUnique();
        }
    }
}
