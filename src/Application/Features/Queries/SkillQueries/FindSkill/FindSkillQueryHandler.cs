using Application.Abstractions;
using Application.DapperQueries.SKillQueries;
using Domain.Shared;

namespace Application.Features.Queries.SkillQueries.FindSkill;

public sealed class FindSkillQueryHandler(ISkillQuery skillQuery)
    : IQueryHandler<FindSkillQuery, IQueryable<FindSkillResponse>>
{
    private readonly ISkillQuery _skillQuery = skillQuery;

    public async Task<Result<IQueryable<FindSkillResponse>>> Handle(FindSkillQuery request, CancellationToken cancellationToken)
    {
        var skillResults = await _skillQuery.FindSkill(request.Filter);

        var skillResponse = skillResults.Select(skill => new FindSkillResponse(skill.Id, skill.Name, skill.Description, skill.Level));

        return Result.Ok(skillResponse);
    }
}