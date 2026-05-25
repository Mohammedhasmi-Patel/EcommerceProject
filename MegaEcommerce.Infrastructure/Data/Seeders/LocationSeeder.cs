using MegaEcommerce.Domain.Entities;
using MegaEcommerce.Infrastructure.Data.Seeders.DTO;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MegaEcommerce.Infrastructure.Data.Seeders
{
    public class LocationSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext _context)
        {
            if (await _context.Countries.AnyAsync()) return;
            var jsonString = await File.ReadAllTextAsync("D:\\FullstackProjects\\MegaEcommerceSolution\\MegaEcommerce.Infrastructure\\Data\\Seeders\\JsonFiles\\countriesStatesCities.json");
            Console.WriteLine("The Country seeder is started......");
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var rawCountries = JsonSerializer.Deserialize<List<RawCountryDto>>(jsonString, options);
            if (rawCountries == null) return;
            var countriesToSave = new List<Country>();

            foreach (var rawCountry in rawCountries)
            {
                var countryEntity = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = rawCountry.Name,
                    Iso3 = rawCountry.Iso3,
                    Iso2 = rawCountry.Iso2,
                    Capital = rawCountry.Capital,
                    Currency = rawCountry.Currency,
                    Region = rawCountry.Region,
                    Subregion = rawCountry.Subregion,
                    Population = rawCountry.Population
                };

                foreach (var rawState in rawCountry.States)
                {
                    var stateEntity = new State
                    {
                        Id = Guid.NewGuid(),
                        Name = rawState.Name,
                        Iso2 = rawState.Iso2,
                        CountryId = countryEntity.Id 
                    };

                    foreach (var rawCity in rawState.Cities)
                    {
                        var cityEntity = new City
                        {
                            Id = Guid.NewGuid(), 
                            Name = rawCity.Name,
                            Latitude = rawCity.Latitude,
                            Longitude = rawCity.Longitude,
                            StateId = stateEntity.Id 
                        };

                        stateEntity.Cities.Add(cityEntity);
                    }

                    countryEntity.States.Add(stateEntity);
                }

                countriesToSave.Add(countryEntity);
            }
            await _context.Countries.AddRangeAsync(countriesToSave);
            await _context.SaveChangesAsync();
            Console.WriteLine("Lication sseeding ending");
        }
        
    }
}
