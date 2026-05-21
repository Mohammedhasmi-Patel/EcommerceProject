

namespace MegaEcommerce.Domain.Entities
{
    public class CartItem 
    {
        /* for the new price whenever the current user access its cart price at that time we will compare with
         * products price if it is different then we will update the cart price
         * 
         * */
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountAmount { get; set; }

        // (UnitPrice - DiscountAmount) * Quantity
        public decimal SubTotal { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }


        // Last time synced with latest product price
        public DateTime LastSyncedAt { get; set; }

        // Navigation Properties
        public ApplicationUser User { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}


