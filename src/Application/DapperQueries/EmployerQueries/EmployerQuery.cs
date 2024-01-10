using Application.DTOs.EmployerDTOs;
using Dapper;

namespace Application.DapperQueries.EmployerQueries;

public class EmployerQuery(DapperDbContext context)
    : IEmployerQuery
{
    private readonly DapperDbContext _context = context;

    public async Task<ReadEmployerDTO?> Get(int Id)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC FINDEMPLOYERBYID @Id";
        var employer = await connection.QueryFirstOrDefaultAsync<ReadEmployerDTO>(sql, new { Id });
        return employer;
    }

    public async Task<IQueryable<ReadEmployerDTO>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = "SELEC * FROM GETALLEMPLOYERS";
        var employerList = await connection.QueryAsync<ReadEmployerDTO>(sql);
        return employerList.AsQueryable();
    }
}