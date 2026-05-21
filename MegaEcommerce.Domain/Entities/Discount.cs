
namespace MegaEcommerce.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string? CouponCode { get; set; }

        public string DiscountType { get; set; } = null!;

        public decimal DiscountValue { get; set; } = 0m;

        public decimal? MaximumDiscountAmount { get; set; }

        public DateTime StartsAt { get; set; }

        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<DiscountProduct> DiscountProducts { get; set; }= new List<DiscountProduct>();
    }
}
