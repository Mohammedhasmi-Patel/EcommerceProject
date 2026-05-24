using MegaEcommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MegaEcommerce.API.Startup
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureProjectServices(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddControllers();
            string dbUrl = configuration.GetConnectionString("Default");

            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(dbUrl);
            });
            return service;
        }
    }
}
