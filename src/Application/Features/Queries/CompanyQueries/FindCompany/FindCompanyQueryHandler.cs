using Application.Abstractions;
using Application.DapperQueries.CompanyQueries;
using Domain.Shared;

namespace Application.Features.Queries.CompanyQueries.FindCompany;

public sealed class FindCompanyQueryHandler(ICompanyQuery companyQuery)
    : IQueryHandler<FindCompanyQuery, IQueryable<FindCompanyResponse>>
{
    private readonly ICompanyQuery _companyQuery = companyQuery;

    public async Task<Result<IQueryable<FindCompanyResponse>>> Handle(FindCompanyQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyQuery.FindCompany(request.Filter);

        var result = companies.Select(company =>
            new FindCompanyResponse
                (company.ID, company.Name, company.Email, company.Address, company.City, company.Country));

        return Result.Ok(result);
    }
}