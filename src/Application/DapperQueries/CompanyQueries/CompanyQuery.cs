using Application.DTOs.CompanyDTOs;
using Dapper;

namespace Application.DapperQueries.CompanyQueries;

public class CompanyQuery(DapperDbContext context) : ICompanyQuery
{
    private readonly DapperDbContext _context = context;

    public async Task<IQueryable<ReadCompanyDTO>> FindCompany(string filter)
    {
        using var connection = _context.CreateConnection();
        var sql = @" EXEC FindCompany @filter";
        var result = await connection.QueryAsync<ReadCompanyDTO>(sql, new { filter });
        return result.AsQueryable();
    }

    public async Task<IQueryable<ReadCompanyWithJobDTO>> FindCompanyWithJobs(string filter)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC FindCompanyWithJob @filter ";
        var result = await connection.QueryAsync<ReadCompanyWithJobDTO>(sql, new { filter });
        return result.AsQueryable();
    }

    public async Task<ReadCompanyDTO?> Get(int Id)
    {
        using var connection = _context.CreateConnection();
        var sql = @"SELECT *
                    FROM dbo.GetAllCompanies
                    WHERE Id = @id";

        var result = await connection.QueryFirstOrDefaultAsync<ReadCompanyDTO>(sql, new { id = Id });
        return result;
    }

    public async Task<IQueryable<ReadCompanyDTO>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = " SELECT * FROM dbo.GetAllCompanies ";
        var result = await connection.QueryAsync<ReadCompanyDTO>(sql);
        return result.AsQueryable();
    }

    public async Task<IQueryable<ReadCompanyWithJobDTO>> GetAllCompaniesWithJobs()
    {
        using var connection = _context.CreateConnection();

        var sql = "select * from GetAllCompaniesWithJobs";
        var result = await connection.QueryAsync<ReadCompanyWithJobDTO, ReadJobOfCompanyDTO, ReadCompanyWithJobDTO>(sql,
            (company, job) =>
            {
                company.Jobs = company.Jobs.Append(job);
                return company;
            }, "", splitOn: "JobId");

        return result.AsQueryable();
    }

    public async Task<IQueryable<ReadJobApplicantsDTO>> GetJobApplicant(int companyId, int jobId)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC dbo.GetJobApplicants @companyId, @jobId";

        var lookup = new Dictionary<int, ReadJobApplicantsDTO>();

        var result = await connection.QueryAsync<ReadJobApplicantsDTO, JobApplicantDto, ReadJobApplicantsDTO>(sql,
                       (jobApplicant, applicant) =>
                       {
                           if (!lookup.TryGetValue(jobApplicant.JobId, out var jobApplicantDTO))
                           {
                               jobApplicantDTO = jobApplicant;
                               lookup.Add(jobApplicantDTO.JobId, jobApplicantDTO);
                           }

                           jobApplicantDTO.Applicants.Add(applicant);
                           return jobApplicantDTO;
                       }, new { companyId, jobId }, splitOn: "CompanyId,JobId,ApplicantId");

        return lookup.Values.AsQueryable();
    }
}