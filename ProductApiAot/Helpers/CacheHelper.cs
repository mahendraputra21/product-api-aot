using System.Text.Json.Serialization.Metadata;
using ProductApiAot.Interfaces;

namespace ProductApiAot.Helpers;

public static class CacheHelper
{
    public static async Task<T?> GetOrSetAsync<T>(
        ICacheService cache,
        string key,
        Func<Task<T>> factory,
        JsonTypeInfo<T?> typeInfo,
        TimeSpan? expiry  = null
    )
    {
        var cached = await cache.GetAsync(key, typeInfo);
        
        if(cached is not null)
            return cached;

        var value = await factory();
        
        await cache.SetAsync(key, value, typeInfo, expiry );
        
        return value;
    }
}