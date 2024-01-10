using Application.DTOs.ResumeDTO;
using Dapper;

namespace Application.DapperQueries.ResumeQueries;

public class ResumeQuery(DapperDbContext context)
    : IResumeQuery
{
    private readonly DapperDbContext _context = context;

    public async Task<GetResumeDTO?> Get(int Id)
    {
        using var connection = _context.CreateConnection();
        var sql = "SELECT  Content, Extension, FileName FROM Resume WHERE Id = @Id";
        var result = await connection.QueryFirstOrDefaultAsync<GetResumeDTO>(sql, new { Id });
        return result;
    }

    public Task<IQueryable<GetResumeDTO>> GetAll()
    {
        throw new NotImplementedException();
    }
}