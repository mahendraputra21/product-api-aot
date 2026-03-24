using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using ProductApiAot.Interfaces;
using ProductApiAot.Models;

namespace ProductApiAot.Repositories;

public class ProductRepository(IConfiguration configuration) 
    : IProductRepository
{
    private IDbConnection CreateConnection()
    {
        return new SqlConnection(
            configuration.GetConnectionString("SqlServer"));
    }
    
    [DapperAot]
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        using var connection = CreateConnection();
        
        return await  connection.QueryAsync<Product>(
            "SELECT Id, Name, Price FROM Products");
    }

    [DapperAot]
    public async Task<Product?> GetByIdAsync(int id)
    {
        using var connection = CreateConnection();
        
        return await connection.QuerySingleOrDefaultAsync<Product>(
            "SELECT Id, Name, Price FROM Products WHERE Id = @id", 
            new { id });
    }

    [DapperAot]
    public async Task<int> CreateAsync(Product product)
    {
        using var connection = CreateConnection();

          var sql = """
          INSERT INTO Products (Name,Price)
          VALUES (@Name,@Price);

          SELECT CAST(SCOPE_IDENTITY() as int)
          """;

        return await connection.ExecuteScalarAsync<int>(sql, product);
    }
    
    [DapperAot]
    public async Task<int> UpdateAsync(Product product)
    {
        using var connection = CreateConnection();

        var sql = """
            UPDATE Products 
            SET Name=@Name, 
                Price=@Price 
            WHERE Id=@Id
            """;
        
        var rows = await connection.ExecuteAsync(sql, product);

        if (rows == 0)
            throw new Exception("Update failed: Product not found");
        
        return rows;
    }

    [DapperAot]
    public async Task<int> DeleteAsync(int id)
    {
        using var connection = CreateConnection();

        var sql = "DELETE FROM Products WHERE Id = @id";

        var rows = await connection.ExecuteAsync(sql, new { id });

        if (rows == 0)
            throw new Exception("Delete failed: Product not found");

        return rows;
    }
}