using Application.DTOs.ResumeDTO;
using Dapper;

namespace Application.DapperQueries.ApplicantResumeQueries;

public class ApplicantResume(DapperDbContext context)
    : IApplicantResume
{
    private readonly DapperDbContext _context = context;

    public async Task<GetResumeDTO> GetResume(int applicantId)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC FindApplicantResume @ApplicantId";
        var result = await connection.QueryFirstOrDefaultAsync<GetResumeDTO>(sql, new { ApplicantId = applicantId });
        return result!;
    }
}