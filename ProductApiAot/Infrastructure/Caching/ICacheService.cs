using System.Text.Json.Serialization.Metadata;

namespace ProductApiAot.Infrastructure.Caching;

public interface ICacheService
{
    public Task<T?> GetAsync<T>(string key, JsonTypeInfo<T> typeInfo);
    
    public Task SetAsync<T>(
        string key, 
        T value, 
        JsonTypeInfo<T> typeInfo, 
        TimeSpan? expiry = null);
    
    public Task RemoveAsync(string key);
    
}