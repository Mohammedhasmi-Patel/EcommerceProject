
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace MegaEcommerce.Application.DTO.Auth
{
    public class RegisterUserRequest
    {
        /*
         *  public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ProfileUrl { get; set; }
        public string? RefreshToken  {get;set;}
        public UserRoleEnum Role { get; set; }

        public DateTime? TokenExpiredTime { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

         * 
         */

        [Required]
        [MaxLength(50, ErrorMessage = $"{nameof(FirstName)} must be less than 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50, ErrorMessage = $"{nameof(LastName)} must be less than 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; } = string.Empty;

        public IFormFile? Profile { get; set; }


    }
}
