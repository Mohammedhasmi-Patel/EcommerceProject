using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaEcommerce.Domain.Entities
{
    public class DiscountProduct : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid DiscountId { get; set; }
        public Guid ProductId { get; set; }
        public Discount Discount { get; set; } = null!;
        public Product Product { get; set; } = null!;

    }
}
