using Application.DTOs.ApplicantDTOs;
using Dapper;

namespace Application.DapperQueries.ApplicantQueries;

public class ApplicantQuery(DapperDbContext context)
    : IApplicantQuery
{
    private readonly DapperDbContext _context = context;

    public async Task<ReadApplicantDTO?> Get(int Id)
    {
        using var connection = _context.CreateConnection();
        var sql = "Exec dbo.FindApplicant @Id";
        var applicant = await connection.QueryFirstOrDefaultAsync<ReadApplicantDTO>(sql, new { Id });
        return applicant;
    }

    public async Task<IQueryable<ReadApplicantDTO>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = "SELECT * FROM  dbo.GetAllApplicants";
        var applicants = await connection.QueryAsync<ReadApplicantDTO>(sql);
        return applicants.AsQueryable();
    }

    public async Task<ReadApplicantWithJobsDTO?> GetApplicantWithJobs(int Id)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC FindApplicantsWithJobs @Id";

        var applicantWithJobsDictionary = new Dictionary<int, ReadApplicantWithJobsDTO>();

        await connection.QueryAsync<ReadApplicantWithJobsDTO, ReadApplicantJobDTO, ReadApplicantWithJobsDTO>(
            sql,
            (applicant, job) =>
            {
                if (!applicantWithJobsDictionary.TryGetValue(applicant.Id, out var existingApplicant))
                {
                    existingApplicant = applicant;
                    existingApplicant.Jobs = new List<ReadApplicantJobDTO>();
                    applicantWithJobsDictionary.Add(existingApplicant.Id, existingApplicant);
                }

                existingApplicant.Jobs.Add(job);
                return existingApplicant;
            },
            new { Id },
            splitOn: "Id"
        );

        return applicantWithJobsDictionary.Values.FirstOrDefault();
    }
}