using Domain.Enums.SkillLevels;

namespace Application.Features.Queries.SkillQueries.GetById;

public sealed record GetSkillByIdResponse
    (int Id, string Name, string Description, Level Level);