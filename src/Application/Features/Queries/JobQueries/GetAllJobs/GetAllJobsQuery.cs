using Application.Abstractions;

namespace Application.Features.Queries.JobQueries.GetAllJobs;

public sealed record GetAllJobsQuery : IQuery<IQueryable<GetAllJobsResponse>>;
