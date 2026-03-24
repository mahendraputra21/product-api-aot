using ProductApiAot.Models;

namespace ProductApiAot.Interfaces;

public interface IProductService
{
    public  Task<IEnumerable<Product>> GetAllAsync();
    public Task<Product?> GetByIdAsync(int id);
    public Task<int> CreateAsync(Product product);
    public Task<int> UpdateAsync(Product product);
    public Task<int> DeleteAsync(int id);
}