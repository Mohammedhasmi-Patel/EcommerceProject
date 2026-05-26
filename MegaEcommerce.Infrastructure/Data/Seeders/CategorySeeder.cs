
using Bogus;
using MegaEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaEcommerce.Infrastructure.Data.Seeders
{
    public class CategorySeeder
    {
        public static async Task SeedAsync(ApplicationDbContext _context,Guid createdBy,int count = 100)
        {
            if (await _context.Categories.AnyAsync()) return;
            Console.WriteLine("Category Seeding is started");

            var faker = new Faker<Category>("en")
                
                        .RuleFor(c => c.Id , _ => Guid.NewGuid())
                        .RuleFor(c => c.Name, c => c.Commerce.Categories(1)[0])
                        .RuleFor(x => x.Slug, (f, u) =>
                        {
                            var slug = u.Name
                                .ToLower()
                                .Replace(" ", "-");

                            return $"{slug}-{Guid.NewGuid().ToString()[..8]}";
                        })
                         .RuleFor(x => x.Icon, f =>$"https://source.unsplash.com/300x300/?{f.Commerce.Categories(1)[0]}")
                         .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                         .RuleFor(x => x.IsFeatured, f =>f.Random.Bool())
                         .RuleFor(x => x.CreatedBy, _ =>createdBy)

                        .RuleFor(x => x.ParentCategoryId, _ =>null);

                        var categories = faker.Generate(count);
                        await _context.Categories.AddRangeAsync(categories);
                        await _context.SaveChangesAsync();

                         Console.WriteLine("Category seeding completed successfully.");


        }

    }
}
