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
        
        // Update Product
        group.MapPut("/{id:int}", async (int id, Product product, IProductService service) =>
        {
            if(id != product.Id)
                return Results.BadRequest("Id Mismatch");

            try
            {
                await service.UpdateAsync(product);
                return Results.NoContent();
            }
            catch (KeyNotFoundException)
            {
                return Results.NotFound();
            }
        });

        // Delete Product
        group.MapDelete("/{id:int}", async (int id, IProductService service) =>
        {
            try
            {
                await service.DeleteAsync(id);
                return Results.NoContent();
            }
            catch (KeyNotFoundException)
            {
                return Results.NotFound();
            }
        });

    }
}