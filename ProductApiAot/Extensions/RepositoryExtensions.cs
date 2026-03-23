using ProductApiAot.Interfaces;
using ProductApiAot.Repositories;

namespace ProductApiAot.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}