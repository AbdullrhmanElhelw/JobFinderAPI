using Domain.Enums.SkillLevels;

namespace Application.Features.Queries.SkillQueries.FindSkill;

public sealed record FindSkillResponse
    (int Id, string Name, string Description, Level Level);