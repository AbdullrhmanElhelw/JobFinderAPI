using Application.Abstractions;
using Application.DapperQueries.JobQueries;
using Domain.Shared;

namespace Application.Features.Queries.JobQueries.FindJob;

public class FindJobQueryHandler(IJobQuery jobQuery) :
    IQueryHandler<FindJobQuery, IQueryable<FindJobResponse>>
{
    private readonly IJobQuery _jobQuery = jobQuery;
    public async Task<Result<IQueryable<FindJobResponse>>> Handle(FindJobQuery request, CancellationToken cancellationToken)
    {
        var jobs = await _jobQuery.FindJob(request.Filter);
        var result = jobs.Select(job =>
            new FindJobResponse
                       (job.Id, job.Title, job.Description, job.CompanyId, job.CompanyName, job.EmployerId, job.EmployerName));

        return Result.Ok(result);
    }
}
