using Application.DTOs.ExperienceDTOs;
using Dapper;

namespace Application.DapperQueries.ExperienceQueries;

public class ExperienceQuery(DapperDbContext context)
    : IExperienceQuery
{
    private readonly DapperDbContext _context = context;

    public async Task<ReadExperienceWithApplicantDTO> GetApplicantExperience(int experienceId, int applicantId)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC [dbo].[FindExperinceWithApplicant] @ExperienceId, @ApplicantId";

        var result = await connection.QueryFirstOrDefaultAsync<ReadExperienceWithApplicantDTO>(
            sql,
            new { ExperienceId = experienceId, ApplicantId = applicantId }
        );

        return result!;
    }

    public async Task<IQueryable<ReadExperienceDTO>> GetApplicantExperiences(int applicantId)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC [dbo].[GetExperience] @ApplicantId";
        var result = await connection.QueryAsync<ReadExperienceDTO>(sql, new { ApplicantId = applicantId });
        return result.AsQueryable();
    }
}