using MegaEcommerce.API.Startup;
using MegaEcommerce.Infrastructure.Data.Seeders;
using MegaEcommerce.API.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureProjectServices();
builder.Services.ConfigureProjectDatabaseService(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

await app.Services.SeedAllAsync();


// Configure the HTTP request pipeline.
app.UseExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
