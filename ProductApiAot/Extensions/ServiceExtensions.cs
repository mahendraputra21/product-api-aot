using ProductApiAot.Interfaces;
using ProductApiAot.Services;

namespace ProductApiAot.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        // Core
        services.AddScoped<ProductService>();

        // Decorator
        services.AddScoped<IProductService>(sp =>
        {
            var inner = sp.GetRequiredService<ProductService>();
            var cache = sp.GetRequiredService<ICacheService>();

            return new CachedProductService(inner, cache);
        });

        return services;
    }
}