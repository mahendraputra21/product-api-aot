using System.Data;
using Microsoft.Data.SqlClient;

namespace ProductApiAot.Infrastructure.Database;

public interface IDbConnectionFactory
{
    public IDbConnection Create();
    public Task<IDbConnection> CreateAsync();
}


public class DbConnectionFactory(IConfiguration configuration)
    : IDbConnectionFactory
{
    private readonly string? _connectionString 
        = configuration.GetConnectionString("SqlServer")
             ?? throw new InvalidOperationException
                 ("Connection string not found");

    public IDbConnection Create()
    {
        return new SqlConnection(_connectionString);
    }

    public async Task<IDbConnection> CreateAsync()
    {
        var connection = new SqlConnection(_connectionString);
        await  connection.OpenAsync();
        return connection;
    }
}