using Application.DapperQueries.QueryBase;
using Application.DTOs.CompanyDTOs;

namespace Application.DapperQueries.CompanyQueries;

public interface ICompanyQuery : IQueryBase<ReadCompanyDTO>
{
    Task<IQueryable<ReadCompanyDTO>> FindCompany(string filter);

    Task<IQueryable<ReadCompanyWithJobDTO>> FindCompanyWithJobs(string filter);

    Task<IQueryable<ReadCompanyWithJobDTO>> GetAllCompaniesWithJobs();

    Task<IQueryable<ReadJobApplicantsDTO>> GetJobApplicant(int companyId, int jobId);
}