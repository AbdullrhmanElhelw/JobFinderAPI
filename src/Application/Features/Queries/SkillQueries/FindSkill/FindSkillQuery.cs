using Application.Abstractions;

namespace Application.Features.Queries.SkillQueries.FindSkill;

public sealed record FindSkillQuery
    (string Filter) : IQuery<IQueryable<FindSkillResponse>>;