using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using ProductApiAot.Interfaces;
using ProductApiAot.Models;

namespace ProductApiAot.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IConfiguration _configuration;

    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private IDbConnection CreateConnection()
    {
        return new SqlConnection(
            _configuration.GetConnectionString("SqlServer"));
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
}