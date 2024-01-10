using Application.Abstractions;
using Application.DapperQueries.SKillQueries;
using Domain.Shared;

namespace Application.Features.Queries.SkillQueries.GetAllWithPaging;

public sealed class GetAllSkillsWithPagingQueryHandler(ISkillQuery skillQuery)
    : IQueryHandler<GetAllSkillsWithPagingQuery, IQueryable<GetAllSkillsWithPagingResponse>>
{
    private readonly ISkillQuery _skillQuery = skillQuery;

    public async Task<Result<IQueryable<GetAllSkillsWithPagingResponse>>> Handle(GetAllSkillsWithPagingQuery request, CancellationToken cancellationToken)
    {
        var skills = await _skillQuery.GetAllWithPaging(request.PageSize, request.PageNumber, request.Filter, request.SortOrder);

        var result = skills.Select(skill => new GetAllSkillsWithPagingResponse(skill.Id, skill.Name, skill.Description, skill.Level));

        return Result.Ok(result);
    }
}