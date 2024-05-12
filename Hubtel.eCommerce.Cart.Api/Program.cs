using Hubtel.eCommerce.Cart.Api.Data;
using Hubtel.eCommerce.Cart.Api.HelperMtds;
using Hubtel.eCommerce.Cart.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICartDatabaseService, CartDatabaseService>();
builder.Services.AddScoped<ICartDbHelperMethods, CartDbHelperMethods>();
builder.Services.AddDbContext<CartDbContext>(o =>
o.UseInMemoryDatabase(builder.Configuration.GetConnectionString("InMemoryDatabase")!));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
