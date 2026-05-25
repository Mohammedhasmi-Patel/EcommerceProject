using MegaEcommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaEcommerce.Infrastructure.Data.Seeders
{
    public static  class SeederExtension
    {
        public static async Task SeedAllAsync(this IServiceProvider service)
        {
            using var scope = service.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await UserSeeder.SeedAsync(userManager);
            await LocationSeeder.SeedAsync(context);



        }
    }
}
