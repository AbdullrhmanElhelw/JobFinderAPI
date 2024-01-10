using Application.Abstractions;
using Application.DapperQueries.CompanyQueries;
using Domain.Shared;

namespace Application.Features.Queries.CompanyQueries.GetAllCompanies;

public sealed class GetAllCompaniesQueryHandler(ICompanyQuery companyQuery)
    : IQueryHandler<GetAllCompaniesQuery, IQueryable<GetAllCompaniesResponse>>
{
    private readonly ICompanyQuery _companyQuery = companyQuery;

    public async Task<Result<IQueryable<GetAllCompaniesResponse>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var result = await _companyQuery.GetAll();
        var response =
            result.Select(company =>
                 new GetAllCompaniesResponse
                     (company.ID, company.Name, company.Description, company.Country, company.City, company.Address, company.Email));

        return Result.Ok(response);
    }
}