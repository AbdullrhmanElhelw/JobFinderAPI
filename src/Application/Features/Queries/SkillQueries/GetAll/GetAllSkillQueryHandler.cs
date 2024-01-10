using Application.Abstractions;
using Application.DapperQueries.SKillQueries;
using Domain.Shared;

namespace Application.Features.Queries.SkillQueries.GetAll;

public sealed class GetAllSkillQueryHandler(ISkillQuery skillQuery)
    : IQueryHandler<GetAllSkillQuery, IQueryable<GetAllSkillsResponse>>
{
    private readonly ISkillQuery _skillQuery = skillQuery;

    public async Task<Result<IQueryable<GetAllSkillsResponse>>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
    {
        var skillList = await _skillQuery.GetAll();

        var result = skillList.Select(skill =>
                new GetAllSkillsResponse(skill.Id, skill.Name, skill.Description, skill.Level));

        return Result.Ok(result);
    }
}