using ProductApiAot.Helpers;
using ProductApiAot.Interfaces;
using ProductApiAot.Models;
using ProductApiAot.Serialization;

namespace ProductApiAot.Services;

public class CachedProductService
    (IProductService inner, 
        ICacheService cache) 
    : IProductService
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await CacheHelper.GetOrSetAsync(
            cache,
            "products:all",
            inner.GetAllAsync,
            AppJsonSerializerContext.Default.IEnumerableProduct,
            TimeSpan.FromMinutes(5)
        ) ?? new List<Product>();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await CacheHelper.GetOrSetAsync(
            cache,
            $"products:{id}",
            () => inner.GetByIdAsync(id),
            AppJsonSerializerContext.Default.Product,
            TimeSpan.FromMinutes(5)
        );
    }

    public async Task<int> CreateAsync(Product product)
    {
        var id = await inner.CreateAsync(product);

        await cache.RemoveAsync("products:all");

        return id;
    }

    public async Task<int> UpdateAsync(Product product)
    {
        var rows = await inner.UpdateAsync(product);
        
        // invalidate cache
        await cache.RemoveAsync("products:all");
        await cache.RemoveAsync($"products:{product.Id}");
        
        return rows;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var rows = await inner.DeleteAsync(id);
        
        //invalidate cache
        await cache.RemoveAsync("products:all");
        await cache.RemoveAsync($"products:{id}");
        
        return rows;
    }
}