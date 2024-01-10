using Application.Abstractions;

namespace Application.Features.Queries.SkillQueries.GetAllWithPaging;

public sealed record GetAllSkillsWithPagingQuery
    (int PageNumber, int PageSize, string Filter = "", string SortOrder = "")
    : IQuery<IQueryable<GetAllSkillsWithPagingResponse>>;