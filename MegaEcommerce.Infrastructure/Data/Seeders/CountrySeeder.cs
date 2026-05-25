using MegaEcommerce.Domain.Entities;
using MegaEcommerce.Infrastructure.Data.Seeders.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MegaEcommerce.Infrastructure.Data.Seeders
{
    public static class CountrySeeder
    {
        

        public static async Task SeedAsync(ApplicationDbContext _context)
        {
            if(await _context.Countries.AnyAsync())
            {
                return;
            }
            var countryJsonData = await File.ReadAllTextAsync("D:\\FullstackProjects\\MegaEcommerceSolution\\MegaEcommerce.Infrastructure\\Data\\Seeders\\JsonFiles\\CountryCodes.json");
            var data = JsonSerializer.Deserialize<List<CountryJson>>(countryJsonData, new JsonSerializerOptions(){
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            });

            if (data is null) return;

            var countries = data.Select(c => new Country()
            {
                Id = Guid.NewGuid(),
                Name = c.Name,
                CountryCode = c.Code,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                DeletedAt = null
            });
            await _context.Countries.AddRangeAsync(countries);
            await _context.SaveChangesAsync();
            Console.WriteLine("Seeding success Countries");



        }

    }
}
