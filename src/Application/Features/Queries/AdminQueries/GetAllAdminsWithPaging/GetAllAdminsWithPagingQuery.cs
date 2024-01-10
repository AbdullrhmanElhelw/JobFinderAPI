using Application.Abstractions;

namespace Application.Features.Queries.AdminQueries.GetAllAdminsWithPaging;

public sealed record GetAllAdminsWithPagingQuery
    (int PageNumber, int PageSize)
    : IQuery<IQueryable<GetAllAdminsWithPagingResponse>>;