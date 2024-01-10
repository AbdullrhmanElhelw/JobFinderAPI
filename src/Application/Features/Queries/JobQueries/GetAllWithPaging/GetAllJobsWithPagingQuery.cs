using Application.Abstractions;

namespace Application.Features.Queries.JobQueries.GetAllWithPaging;

public sealed record GetAllJobsWithPagingQuery
    (int PageSize, int PageNumber, string Filter = "")
    : IQuery<IQueryable<GetAllJobsWithPagingResponse>>;