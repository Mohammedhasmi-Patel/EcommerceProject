using MegaEcommerce.API.Startup;
using MegaEcommerce.Infrastructure.Data.Seeders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureProjectServices();
builder.Services.ConfigureProjectDatabaseService(builder.Configuration);



var app = builder.Build();

await app.Services.SeedAllAsync();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
