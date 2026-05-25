using MegaEcommerce.Domain.Entities;
using MegaEcommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MegaEcommerce.API.Startup
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureProjectServices(this IServiceCollection service)
        {
            service.AddControllers();
            service.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                                    .AddEntityFrameworkStores<ApplicationDbContext>()
                                    .AddDefaultTokenProviders();


            return service;
        }
    }
}
