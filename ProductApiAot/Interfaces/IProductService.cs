using ProductApiAot.Models;

namespace ProductApiAot.Interfaces;

public interface IProductService
{
    public  Task<IEnumerable<Product>> GetAllAsync();
    public Task<Product?> GetByIdAsync(int id);
    public Task<int> CreateAsync(Product product);
}