using Application.Abstractions;

namespace Application.Features.Queries.JobQueries.FindJob;

public sealed record FindJobQuery(string Filter) : IQuery<IQueryable<FindJobResponse>>;
