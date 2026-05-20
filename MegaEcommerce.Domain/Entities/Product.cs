
using System.ComponentModel.DataAnnotations;

namespace MegaEcommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Slug { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? StrikethroughPrice { get; set; }
        public int StockQuantity { get; set; }

        public Guid CreatedBy { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPublished { get; set; } = true;


        public Category Category { get; set; } = null!;

        public ApplicationUser CreatedByUser { get; set; } = null!;

        public ICollection<CartItem> CartItems { get; set; }= new List<CartItem>();

        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
