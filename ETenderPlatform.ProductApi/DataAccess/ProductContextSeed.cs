using ETenderPlatform.ProductApi.Entities;
using MongoDB.Driver;

namespace ETenderPlatform.ProductApi.DataAccess;

public static class ProductContextSeed
{
    public static void SeedData(IMongoCollection<Product> productsCollection)
    {
        bool existProduct = productsCollection.Find(p => true).Any();
        if (!existProduct)
        {
            productsCollection.InsertManyAsync(GetConfigureProducts());
        }
    }

    private static IEnumerable<Product> GetConfigureProducts()
    {
        return new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product - 1",
                Summary = "Product - 1 Summary",
                Description = "Product - 1 Long Description",
                Price = 470.99M,
                Category = "Category - 1",
                ImageFile = "product_1.png"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product - 2",
                Summary = "Product - 2 Summary",
                Description = "Product - 2 Long Description",
                Price = 129.99M,
                Category = "Category - 1",
                ImageFile = "product_2.png"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product - 3",
                Summary = "Product - 3 Summary",
                Description = "Product - 3 Long Description",
                Price = 670.99M,
                Category = "Category - 2",
                ImageFile = "product_3.png"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product - 4",
                Summary = "Product - 4 Summary",
                Description = "Product - 4 Long Description",
                Price = 970.99M,
                Category = "Category - 3",
                ImageFile = "product_4.png"
            }
        };
    }
}