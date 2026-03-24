using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using StackExchange.Redis;

namespace ProductApiAot.Infrastructure.Caching;

public class CacheService
    (IConnectionMultiplexer redis) : ICacheService
{
    private readonly IDatabase _db = redis.GetDatabase();

    public async Task<T?> GetAsync<T>(string key, JsonTypeInfo<T> typeInfo)
    {
        var value = await _db.StringGetAsync(key);
        
        if (value.IsNullOrEmpty)
            return default;
        
        var json = value.ToString();
        
        if(string.IsNullOrEmpty(json))
            return default;
        
        return JsonSerializer.Deserialize(json, typeInfo);
    }

    public async Task SetAsync<T>(
        string key, 
        T value, 
        JsonTypeInfo<T> typeInfo, 
        TimeSpan? expiry = null)
    {
        var json = JsonSerializer.Serialize(value,  typeInfo);
        
        await _db.StringSetAsync(
            key, 
            json, 
            expiry, 
            When.Always, 
            CommandFlags.None);
    }

    public async Task RemoveAsync(string key)
    {
        await _db.KeyDeleteAsync(key);  
    }
}