using MegaEcommerce.API.Startup;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureProjectServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
