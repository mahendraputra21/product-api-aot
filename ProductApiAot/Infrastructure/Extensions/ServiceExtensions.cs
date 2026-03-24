using ProductApiAot.Features.Products.Interfaces;
using ProductApiAot.Features.Products.Services;
using ProductApiAot.Infrastructure.Caching;

namespace ProductApiAot.Infrastructure.Extensions;

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