using ETenderPlatform.ProductApi.DataAccess.Interfaces;
using ETenderPlatform.ProductApi.Entities;
using ETenderPlatform.ProductApi.Repositories.Interfaces;
using MongoDB.Driver;

namespace ETenderPlatform.ProductApi.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly IProductContext _context;

    public ProductRepository(IProductContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.Find(p => true).ToListAsync();
    }

    public async Task<Product> GetById(Guid id)
    {
        return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetAllByName(string name)
    {
        var filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);
        return await _context.Products.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByCategoryName(string categoryName)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
        return await _context.Products.Find(filter).ToListAsync();
    }

    public async Task Create(Product product)
    {
        await _context.Products.InsertOneAsync(product);
    }

    public async Task<bool> Update(Product product)
    {
        var updateResult =
            await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var filter = Builders<Product>.Filter.Eq(m => m.Id, id);
        DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}