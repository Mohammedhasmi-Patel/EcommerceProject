using MegaEcommerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace MegaEcommerce.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ProfileUrl { get; set; }
        public string? RefreshToken  {get;set;}
        public UserRoleEnum Role { get; set; }

        public DateTime? TokenExpiredTime { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // A User has Many Address 
        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();


        // A User Create Many Product
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        // A User Can Create Many Categories
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        // A User Has Many Orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>(); 
    }
}
