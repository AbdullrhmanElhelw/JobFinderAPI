using Application.DTOs.JobDTOs;
using Dapper;
using Domain.Models;

namespace Application.DapperQueries.JobQueries;

public class JobQuery(DapperDbContext context) : IJobQuery
{
    private readonly DapperDbContext _context = context;

    public async Task<IQueryable<ReadJobDTO>> FindJob(string Filter)
    {
        using var connection = _context.CreateConnection();
        var sql = """Exec FindJob @Filter """;
        var jobs = await connection.QueryAsync<ReadJobDTO>(sql, new { Filter });
        return jobs.AsQueryable();
    }

    public async Task<ReadJobDTO?> Get(int Id)
    {
        using var connection = _context.CreateConnection();
        var sql = """SELECT * FROM GetAllJobs WHERE Id = @Id""";
        var job = await connection.QuerySingleOrDefaultAsync<ReadJobDTO>(sql, new { Id });
        return job;
    }

    public async Task<IQueryable<ReadJobDTO>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """SELECT * FROM GetAllJobs""";
        var jobs = await connection.QueryAsync<ReadJobDTO>(sql);
        return jobs.AsQueryable();
    }

    public async Task<Job?> GetToDelete(int Id)
    {
        using var connection = _context.CreateConnection();
        var sql = """ EXEC FindJobToDelete @Id """;
        var job = await connection.QuerySingleOrDefaultAsync<Job>(sql, new { Id });
        return job;
    }

    public async Task<UpdateJobDTO?> GetToUpdate(int Id)
    {
        using var connection = _context.CreateConnection();
        var sql = """Exec FindJobToUpdate @Id""";
        var job = await connection.QuerySingleOrDefaultAsync<UpdateJobDTO>(sql, new { Id });
        return job;
    }

    public async Task<IQueryable<ReadJobDTO>> GetWithPaging(int pageSize, int pageNumber, string filter = "")
    {
        using var connection = _context.CreateConnection();
        var sql = "exec [dbo].[GetPagedJobs] @pageSize, @pageNumber, @filter";
        var jobs = await connection.QueryAsync<ReadJobDTO>(sql, new { pageSize, pageNumber, filter });
        return jobs.AsQueryable();
    }
}