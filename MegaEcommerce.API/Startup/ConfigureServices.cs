using MegaEcommerce.API.Filters;
using MegaEcommerce.Application.Services;
using MegaEcommerce.Application.ServicesInterface;
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
            service.AddControllers(options =>
            {
                options.Filters.Add<ValidationModelAttribute>();

            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            service.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                                    .AddEntityFrameworkStores<ApplicationDbContext>()
                                    .AddDefaultTokenProviders();
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            service.AddScoped<IAuthService, AuthService>();

            return service;
        }
    }
}
