using ETenderPlatform.ProductApi.DataAccess.Interfaces;
using ETenderPlatform.ProductApi.Entities;
using ETenderPlatform.ProductApi.Settings;
using MongoDB.Driver;

namespace ETenderPlatform.ProductApi.DataAccess;

public class ProductContext: IProductContext
{
    public IMongoCollection<Product> Products { get; set; }
    
    public ProductContext(IProductDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        Products = database.GetCollection<Product>(settings.CollectionName);
        ProductContextSeed.SeedData(Products);
    }
}