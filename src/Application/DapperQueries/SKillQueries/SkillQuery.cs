using Application.DTOs.SkillDTOs;
using Dapper;
using Domain.Models;

namespace Application.DapperQueries.SKillQueries;

public class SkillQuery(DapperDbContext context) : ISkillQuery
{
    private readonly DapperDbContext _context = context;

    public async Task<IQueryable<Skill>> FindSkill(string filter)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC FINDSKILL @filter";
        var skills = await connection.QueryAsync<Skill>(sql, new { filter });
        return skills.AsQueryable();
    }

    public async Task<Skill?> Get(int Id)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC FINDSKILLBYID @Id";
        var skill = await connection.QuerySingleOrDefaultAsync<Skill>(sql, new { Id });
        return skill;
    }

    public async Task<IQueryable<Skill>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = "SELECT * FROM GetAllSkill";
        var skills = await connection.QueryAsync<Skill>(sql);
        return skills.AsQueryable();
    }

    public async Task<IQueryable<Skill>> GetAllWithPaging(int pageSize, int pageNumber, string sortColumn = null!, string SortOrder = null!)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC [dbo].[GetAllSkillWithPaging]  @PageNumber, @PageSize, @SortColumn, @SortOrder";
        var skills = await connection.QueryAsync<Skill>(sql, new { pageSize, pageNumber, sortColumn, SortOrder });
        return skills.AsQueryable();
    }

    public async Task<IQueryable<ReadSkillDTO>> GetApplicantSkill(int applicantId)
    {
        using var connection = _context.CreateConnection();
        var sql = "Exec GetApplicantSkill @applicantId";
        var skills = await connection.QueryAsync<ReadSkillDTO>(sql, new { applicantId });
        return skills.AsQueryable();
    }
}