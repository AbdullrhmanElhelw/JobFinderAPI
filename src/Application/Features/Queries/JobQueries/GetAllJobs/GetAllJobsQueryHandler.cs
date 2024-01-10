using Application.Abstractions;
using Application.DapperQueries.JobQueries;
using Domain.Shared;

namespace Application.Features.Queries.JobQueries.GetAllJobs;

public sealed class GetAllJobsQueryHandler(IJobQuery jobQuery) :
    IQueryHandler<GetAllJobsQuery, IQueryable<GetAllJobsResponse>>
{
    private readonly IJobQuery _jobQuery = jobQuery;
    public async Task<Result<IQueryable<GetAllJobsResponse>>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await _jobQuery.GetAll();
        var result = jobs.Select(job =>
            new GetAllJobsResponse
            (job.Id, job.Title, job.Description, job.CompanyId, job.CompanyName, job.EmployerId, job.EmployerName));

        return Result.Ok(result);
    }
}
