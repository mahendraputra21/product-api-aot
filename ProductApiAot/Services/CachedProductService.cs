using ProductApiAot.Helpers;
using ProductApiAot.Interfaces;
using ProductApiAot.Models;
using ProductApiAot.Serialization;

namespace ProductApiAot.Services;

public class CachedProductService : IProductService
{
    private readonly IProductService _inner;
    private readonly ICacheService _cache;


    public CachedProductService(IProductService inner, ICacheService cache)
    {
        _inner = inner;
        _cache = cache;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await CacheHelper.GetOrSetAsync(
            _cache,
            "products:all",
            () => _inner.GetAllAsync(),
            AppJsonSerializerContext.Default.IEnumerableProduct,
            TimeSpan.FromMinutes(5)
        ) ?? new List<Product>();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _inner.GetByIdAsync(id);
    }

    public async Task<int> CreateAsync(Product product)
    {
        var id = await _inner.CreateAsync(product);

        await _cache.RemoveAsync("products:all");

        return id;
    }
}