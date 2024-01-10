using Application.Abstractions;
using Application.DapperQueries.ApplicantQueries;
using Application.DapperQueries.ApplicantResumeQueries;
using Domain.Shared;

namespace Application.Features.Queries.ResumeQueries.GetResume;

public class GetResumeQueryHandler(IApplicantResume resumeQuery, IApplicantQuery applicantQuery)
    : IQueryHandler<GetResumeQuery, GetResumeResponse>
{
    private readonly IApplicantResume _resumeQuery = resumeQuery;
    private readonly IApplicantQuery _applicantQuery = applicantQuery;

    public async Task<Result<GetResumeResponse>> Handle(GetResumeQuery request, CancellationToken cancellationToken)
    {
        var applicant = await _applicantQuery.Get(request.ApplicantId);
        if (applicant is null)
            return Result.Fail<GetResumeResponse>("User " + Error.NotFound);

        var resume = await _resumeQuery.GetResume(request.ApplicantId);

        if (resume is null)
            return Result.Fail<GetResumeResponse>(Error.NotFound);

        var response = new GetResumeResponse(Content: resume.Content, Extension: resume.Extension, FileName: resume.FileName);
        return Result.Ok(response);
    }
}