
using System.ComponentModel.DataAnnotations;

namespace MegaEcommerce.Domain.Entities
{
    public class OrderAddress : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }

        public string RecipientName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Landmark { get; set; } = string.Empty;

        public string CountryName { get; set; } = string.Empty;
        public string StateName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        // Navigation Properties

        public Order Order { get; set; } = null!;


    }
}
