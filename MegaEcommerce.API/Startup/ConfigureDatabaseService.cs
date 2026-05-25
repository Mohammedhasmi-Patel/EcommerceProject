using MegaEcommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MegaEcommerce.Infrastructure.Data.Seeders;

namespace MegaEcommerce.API.Startup
{
    public static class ConfigureDatabaseService
    {
        public static  IServiceCollection ConfigureProjectDatabaseService(this IServiceCollection service,IConfiguration configuration)
        {
            string dbUrl = configuration.GetConnectionString("Default");

            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(dbUrl);
            });

            return service;
        }
    }
}
