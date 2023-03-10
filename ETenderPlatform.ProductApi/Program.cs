using ETenderPlatform.ProductApi.DataAccess;
using ETenderPlatform.ProductApi.DataAccess.Interfaces;
using ETenderPlatform.ProductApi.Repositories;
using ETenderPlatform.ProductApi.Repositories.Interfaces;
using ETenderPlatform.ProductApi.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<ProductDatabaseSettings>(builder.Configuration.GetSection(nameof(ProductDatabaseSettings)));
builder.Services.AddSingleton<IProductDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ProductDatabaseSettings>>().Value);
builder.Services.AddTransient<IProductContext, ProductContext>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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