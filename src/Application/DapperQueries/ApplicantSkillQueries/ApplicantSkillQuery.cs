using Application.DTOs.ApplicantSkillDTO;
using Dapper;

namespace Application.DapperQueries.ApplicantSkillQueries;

public class ApplicantSkillQuery(DapperDbContext context)
    : IApplicantSkillQuery
{
    private readonly DapperDbContext _context = context;

    public async Task<ReadSkillDTO> GetApplicantSkill(int applicantId, int skillId)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC FindApplicantSkill @SkillId, @ApplicantId";
        var result = await connection.QueryFirstOrDefaultAsync<ReadSkillDTO>(sql, new { SkillId = skillId, ApplicantId = applicantId });
        return result;
    }
}