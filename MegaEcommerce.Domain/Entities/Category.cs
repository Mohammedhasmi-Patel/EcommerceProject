
using System.ComponentModel.DataAnnotations;

namespace MegaEcommerce.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public bool IsFeatured { get; set; } // for displaying in home page
        public Guid CreatedBy { get; set; }

        // Relations
        public Category? ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        public ApplicationUser CreatedByUser { get; set; } = null!;

    }
}
