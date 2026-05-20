using Microsoft.AspNetCore.Identity;

namespace MegaEcommerce.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ProfileUrl { get; set; }
        public string? RefreshToken  {get;set;}
        public DateTime TokenExpiredTime { get; set; }

        // A User has Many Address 
        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();


        // A User Create Many Product
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        // A User Can Create Many Categories
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        // A User Has Many CartItems
        // A User Has Many FavouriteProducts
        // A User Has Many Orders
        // A User Has Many Transaction Transactions

    }
}
