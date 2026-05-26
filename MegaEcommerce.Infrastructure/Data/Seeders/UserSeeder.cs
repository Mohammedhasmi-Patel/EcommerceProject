using Bogus;
using MegaEcommerce.Domain.Entities;
using MegaEcommerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace MegaEcommerce.Infrastructure.Data.Seeders
{
    public class UserSeeder
    {

        public static async Task SeedAsync(UserManager<ApplicationUser> userManager,int count = 100)
        {
            if (await userManager.Users.AnyAsync())
            {
                Console.WriteLine("Database already has users. Skipping seeding.");
                return; // Agar data hai, to yahi se baahar nikal jayein
            }

            var superAdmin = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Hasmi",
                LastName = "Patel",
                Email = "superhasmi@gmail.com",
                UserName = "superadmin",
                EmailConfirmed = true,
                Role = UserRoleEnum.SuperAdmin,
                ProfileUrl = "https://i.pravatar.cc/300?img=1",
                RefreshToken = Guid.NewGuid().ToString(),
                TokenExpiredTime = DateTime.UtcNow.AddDays(30),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            var superAdminResult = await userManager.CreateAsync(
                superAdmin,
                "Admin@123");

            if (!superAdminResult.Succeeded)
            {
                foreach (var error in superAdminResult.Errors)
                {
                    Console.WriteLine(error.Description);
                }
            }

            var faker = new Faker<ApplicationUser>("en_IND")
                            
                        .RuleFor(x => x.Id, _ => Guid.NewGuid())

                        .RuleFor(x => x.FirstName, f => f.Name.FirstName())

                        .RuleFor(x => x.LastName, f => f.Name.LastName())

                        .RuleFor(x => x.Email, (f, u) =>
                            $"{u.FirstName.ToLower()}.{u.LastName.ToLower()}{f.Random.Int(10, 999)}@gmail.com")
                        .RuleFor(x => x.NormalizedEmail, (f, u) => u.Email?.ToLower())
                        .RuleFor(x => x.NormalizedUserName, (f, u) => u.UserName?.ToLower())

                        .RuleFor(x => x.UserName, (f, u) =>
                            $"{u.FirstName.ToLower()}{u.LastName.ToLower()}{f.Random.Int(10, 999)}")

                        .RuleFor(x => x.ProfileUrl, f =>
                            $"https://i.pravatar.cc/300?img={f.Random.Int(1, 70)}")

                        .RuleFor(x => x.Role, f =>
                            f.PickRandom<UserRoleEnum>())

                        .RuleFor(x => x.RefreshToken, _ =>
                            Guid.NewGuid().ToString())

                        .RuleFor(x => x.TokenExpiredTime, f =>
                            DateTime.UtcNow.AddDays(f.Random.Int(1, 30)))

                        .RuleFor(x => x.CreatedAt, f =>
                            f.Date.Past(2))

                        .RuleFor(x => x.UpdatedAt, f =>
                            f.Date.Recent())

                        .RuleFor(x => x.IsDeleted, false)

            .RuleFor(x => x.DeletedAt, _ => null);

            var users = faker.Generate(count);
            foreach(var user in users)
            {
                var result = await userManager.CreateAsync(user,"Hasmi@123");
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }

            }



            Console.WriteLine("Seeding success Users");

             await Task.FromResult(users);

        }
    }
}
