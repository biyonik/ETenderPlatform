using ETenderPlatform.ProductApi.Entities;
using MongoDB.Driver;

namespace ETenderPlatform.ProductApi.DataAccess.Interfaces;

public interface IProductContext
{
    public IMongoCollection<Product> Products { get; set; }
}