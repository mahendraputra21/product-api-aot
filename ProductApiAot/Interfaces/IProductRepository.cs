using ProductApiAot.Models;

namespace ProductApiAot.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    
    Task<Product?> GetByIdAsync(int id);
    
    Task<int> CreateAsync(Product product);
}