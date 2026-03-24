using ProductApiAot.Features.Products.Models;

namespace ProductApiAot.Features.Products.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    
    Task<Product?> GetByIdAsync(int id);
    
    Task<int> CreateAsync(Product product);
    
    Task<int> UpdateAsync(Product product);
    
    Task<int> DeleteAsync(int id);
}