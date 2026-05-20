namespace MegaEcommerce.API.Startup
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureProjectServices(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddControllers();
            return service;
        }
    }
}
