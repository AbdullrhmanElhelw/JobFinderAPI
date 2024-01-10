using Application.Abstractions;
using Application.DapperQueries.ApplicantQueries;
using Application.DTOs.ApplicantDTOs;
using Domain.Shared;

namespace Application.Features.Queries.ApplicantQueries.GetAllApplicants;

public sealed class GetAllApplicantsQueryHandler(IApplicantQuery applicantQuery)
    : IQueryHandler<GetAllApplicantsQuery, IQueryable<ReadApplicantDTO>>
{
    private readonly IApplicantQuery _applicantQuery = applicantQuery;

    public async Task<Result<IQueryable<ReadApplicantDTO>>> Handle(GetAllApplicantsQuery request, CancellationToken cancellationToken)
    {
        var applicants = await _applicantQuery.GetAll();

        if (applicants is null)
            return Result.Fail<IQueryable<ReadApplicantDTO>>("No applicants exist");

        return Result.Ok(applicants);
    }
}