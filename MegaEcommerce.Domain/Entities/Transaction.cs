using MegaEcommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaEcommerce.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string TransactionId { get; set; } = null!;
        public string Gateway { get; set; } = null!;
        public PaymentMethodEnum PaymentMethod { get; set; }
        public decimal Amount { get; set; } = 0m;
        public TransactionStatusEnum Status { get; set; }

        public string? GatewayResponse { get; set; }

        public DateTime? PaymentDate { get; set; }


    }
}
