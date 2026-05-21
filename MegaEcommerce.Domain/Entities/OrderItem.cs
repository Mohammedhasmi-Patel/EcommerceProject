
using System.ComponentModel.DataAnnotations;

namespace MegaEcommerce.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;



    }
}
