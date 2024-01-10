using Application.Abstractions;
using Application.DapperQueries.SKillQueries;
using Domain.Shared;

namespace Application.Features.Queries.SkillQueries.GetById;

public sealed class GetSkillByIdQueryHandler(ISkillQuery skillQuery)
    : IQueryHandler<GetSkillByIdQuery, GetSkillByIdResponse>
{
    private readonly ISkillQuery _skillQuery = skillQuery;

    public async Task<Result<GetSkillByIdResponse>> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        var skill = await _skillQuery.Get(request.Id);
        if (skill is null)
            return Result.Fail<GetSkillByIdResponse>("Skill not found");

        return Result.Ok(new GetSkillByIdResponse(skill.Id, skill.Name, skill.Description, skill.Level));
    }
}