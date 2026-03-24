

using ProductApiAot.Features.Products.Interfaces;
using ProductApiAot.Features.Products.Repositories;

namespace ProductApiAot.Infrastructure.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}