using ETenderPlatform.ProductApi.Entities;

namespace ETenderPlatform.ProductApi.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(Guid id);
    Task<IEnumerable<Product>> GetAllByName(string name);
    Task<IEnumerable<Product>> GetProductByCategoryName(string categoryName);
    Task Create(Product product);
    Task<bool> Update(Product product);
    Task<bool> Delete(Guid id);
}