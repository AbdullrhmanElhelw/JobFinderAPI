using Application.Abstractions;
using Application.DapperQueries.CompanyQueries;
using Domain.Shared;

namespace Application.Features.Queries.CompanyQueries.GetAllCompaniesWithJobs;

public sealed class GetAllCompaniesWithJobsQueryHandler(ICompanyQuery companyQuery)
    : IQueryHandler<GetAllCompaniesWithJobsQuery, IQueryable<GetAllCompaniesWithJobsResponse>>
{
    private readonly ICompanyQuery _companyQuery = companyQuery;
    public async Task<Result<IQueryable<GetAllCompaniesWithJobsResponse>>> Handle
        (GetAllCompaniesWithJobsQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyQuery.GetAllCompaniesWithJobs();
        var response = companies.Select(company =>
            new GetAllCompaniesWithJobsResponse
                (
                    company.Id,
                    company.Name,
                    company.Description,
                    company.Country,
                    company.City,
                    company.Address,
                    company.Email,
                    company.Jobs
                 ));
        return Result.Ok(response);
    }
}
