using MegaEcommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaEcommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        [StringLength(15)]
        public string OrderNumber { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } = 0.00m;

        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingFees { get; set; } = 0.00m;

        public PaymentStatusEnum PaymentStatus { get; set; }

        public PaymentMethodEnum PaymentMethod { get; set; } = null!;

        public OrderStatusEnum Status { get; set; } = null!;

        // Navigation Properties
        public ApplicationUser User { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();

        public OrderAddress OrderAddress { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
