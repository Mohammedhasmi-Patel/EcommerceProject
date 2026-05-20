
using System.ComponentModel.DataAnnotations;

namespace MegaEcommerce.Domain.Entities
{
    public class UserAddress : BaseEntity
    {
        [Key]
        public Guid UserId { get; set; }
        public string RecipientName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Landmark { get; set; }
        public Guid CountryId { get; set; }
        public Guid StateId { get; set; }
        public Guid CityId { get; set; }
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public string ZipCode { get; set; } = null!;
        public bool IsDefault { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public Country Country { get; set; } = null!;
        public State State { get; set; } = null!;
        public City City { get; set; } = null!;
    }
}
