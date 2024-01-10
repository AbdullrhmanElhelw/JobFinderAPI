using Application.Abstractions;
using Application.DapperQueries.ApplicantQueries;
using Application.DTOs.ApplicantDTOs;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Queries.ApplicantQueries.GetApplicantJobs;

public sealed class GetApplicantJobsQueryHandler(IApplicantQuery applicantQuery, UserManager<Applicant> userManager)
    : IQueryHandler<GetApplicantJobsQuery, ReadApplicantWithJobsDTO>
{
    private readonly IApplicantQuery _applicantQuery = applicantQuery;
    private readonly UserManager<Applicant> _userManager = userManager;

    public async Task<Result<ReadApplicantWithJobsDTO>> Handle(GetApplicantJobsQuery request, CancellationToken cancellationToken)
    {
        var applicantExists = await _userManager.FindByIdAsync(request.Id.ToString());
        if (applicantExists == null)
            return Result.Fail<ReadApplicantWithJobsDTO>($"Applicant with Id {request.Id} does not exist");

        var applicantJobs = await _applicantQuery.GetApplicantWithJobs(request.Id);
        return applicantJobs is null
            ? Result.Fail<ReadApplicantWithJobsDTO>($"Applicant with Id {request.Id} does not Apply for Any Job ")
            : Result.Ok(applicantJobs);
    }
}