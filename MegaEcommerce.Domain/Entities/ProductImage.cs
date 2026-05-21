
using System.ComponentModel.DataAnnotations;

namespace MegaEcommerce.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string? AltText { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPrimary { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public Product Product { get; set; } = null!;

    }
}
