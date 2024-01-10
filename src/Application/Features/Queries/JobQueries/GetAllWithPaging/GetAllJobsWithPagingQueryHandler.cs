using Application.Abstractions;
using Application.DapperQueries.JobQueries;
using Domain.Shared;

namespace Application.Features.Queries.JobQueries.GetAllWithPaging;

public sealed class GetAllJobsWithPagingQueryHandler(IJobQuery jobQuery)
    : IQueryHandler<GetAllJobsWithPagingQuery, IQueryable<GetAllJobsWithPagingResponse>>
{
    private readonly IJobQuery _jobQuery = jobQuery;

    public async Task<Result<IQueryable<GetAllJobsWithPagingResponse>>> Handle(GetAllJobsWithPagingQuery request, CancellationToken cancellationToken)
    {
        var jobList = await _jobQuery.GetWithPaging(request.PageSize, request.PageNumber, request.Filter);
        var jobListResponse = jobList.Select
            (job => new GetAllJobsWithPagingResponse(job.Id, job.Title, job.Description, job.CompanyId, job.CompanyName, job.EmployerId, job.EmployerName));

        return Result.Ok(jobListResponse);
    }
}