using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Application.DapperQueries;

public class DapperDbContext
{
    private readonly string _connectionString;
    private readonly IConfiguration _configuration;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = configuration.GetConnectionString("JobFinderAPI") ??
                                throw new("Connection string not found");
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("JobFinderAPI"));
    }
}