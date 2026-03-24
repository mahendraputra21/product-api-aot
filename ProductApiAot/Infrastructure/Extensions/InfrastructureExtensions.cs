using ProductApiAot.Infrastructure.Database;
using ProductApiAot.Serialization;
using StackExchange.Redis;

namespace ProductApiAot.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // DBConnection
        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        
        // Redis
        services.AddSingleton<IConnectionMultiplexer>(_ =>
        {
            var config = configuration["Redis:Connection"];

            if (string.IsNullOrWhiteSpace(config))
                throw new Exception("Redis connection is not configured");

            return ConnectionMultiplexer.Connect(config);
        });
        
        // AOT JSON
        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(
                0,
                AppJsonSerializerContext.Default);
        });

        return services;
    }
}