using Application.Abstractions;
using Application.DapperQueries.EmployerQueries;
using Domain.Shared;

namespace Application.Features.Queries.EmployerQueries.GetEmployerById;

public sealed class GetEmployerByIdQueryHandler(IEmployerQuery employerQuery)
    : IQueryHandler<GetEmployerByIdQuery, GetEmployerByIdResponse>
{
    private readonly IEmployerQuery _employerQuery = employerQuery;

    public async Task<Result<GetEmployerByIdResponse>> Handle(GetEmployerByIdQuery request, CancellationToken cancellationToken)
    {
        var employer = await _employerQuery.Get(request.Id);

        if (employer is null)
            return Result.Fail<GetEmployerByIdResponse>("Employer not found");

        var employerResponse = new GetEmployerByIdResponse
            (employer.EmployerName, employer.Email, employer.Name, employer.Description);

        return Result.Ok(employerResponse);
    }
}