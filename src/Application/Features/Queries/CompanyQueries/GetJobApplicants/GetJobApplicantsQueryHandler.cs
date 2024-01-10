using Application.Abstractions;
using Application.DapperQueries.CompanyQueries;
using Application.DTOs.CompanyDTOs;
using Domain.Shared;

namespace Application.Features.Queries.CompanyQueries.GetJobApplicants;

public sealed class GetJobApplicantsQueryHandler(ICompanyQuery companyQuery)
    : IQueryHandler<GetJobApplicantsQuery, IQueryable<ReadJobApplicantsDTO>>
{
    private readonly ICompanyQuery _companyQuery = companyQuery;

    public async Task<Result<IQueryable<ReadJobApplicantsDTO>>> Handle(GetJobApplicantsQuery request, CancellationToken cancellationToken)
    {
        var result = await _companyQuery.GetJobApplicant(request.CompanyId, request.JobId);

        return result.Any()
            ? Result.Ok(result)
            : Result.Fail<IQueryable<ReadJobApplicantsDTO>>("No Applications Found");
    }
}