using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaEcommerce.Domain.Enums
{
    public enum TransactionStatusEnum
    {
        Pending,     // Transaction is initialized but waiting on the provider
        Processing,  // Payment gateway is actively processing the charge
        Success,     // Money cleared successfully
        Failed,      // Declined, insufficient funds, or gateway error
        Cancelled,   // User backed out before completion
        Refunded,    // Money was successfully returned to the customer
        Voided       // Transaction was cancelled before authorization cleared
    }
}
