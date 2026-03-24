using ProductApiAot.Interfaces;
using ProductApiAot.Models;

namespace ProductApiAot.Services;

public class ProductService
    (IProductRepository productRepository)
    : IProductService
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await  productRepository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await productRepository.GetByIdAsync(id);
    }

    public async Task<int> CreateAsync(Product product)
    {
        return await productRepository.CreateAsync(product);
    }

    public async Task<int> UpdateAsync(Product product)
    {
        return await productRepository.UpdateAsync(product);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await productRepository.DeleteAsync(id);
    }
}