
using System.ComponentModel.DataAnnotations;

namespace MegaEcommerce.Domain.Entities
{
    public class UserAddress : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string RecipientName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Landmark { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public string ZipCode { get; set; } = null!;
        public bool IsDefault { get; set; }

        public ApplicationUser User { get; set; } = null!;

    }
}
