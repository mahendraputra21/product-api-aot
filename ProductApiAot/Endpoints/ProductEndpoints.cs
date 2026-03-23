using ProductApiAot.Interfaces;
using ProductApiAot.Models;

namespace ProductApiAot.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoint(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");
        
        // Get All products
        group.MapGet("/", async (IProductService service) =>
        {
            return await service.GetAllAsync();
        });
        
        // Get Product By Id
        group.MapGet("/{id:int}", async (int id, IProductService service) =>
        {
            var product = await service.GetByIdAsync(id);
            
            return product is null 
                ? Results.NotFound() 
                : Results.Ok(product); 
        });
        
        // Create new Product
        group.MapPost("/", async (Product product, IProductService service) =>
        {
            var id = await service.CreateAsync(product);
            
            return Results.Created($"/products/{id}", product);
        });

    }
}