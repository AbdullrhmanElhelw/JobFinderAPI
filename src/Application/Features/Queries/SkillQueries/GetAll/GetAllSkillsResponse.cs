using Domain.Enums.SkillLevels;

namespace Application.Features.Queries.SkillQueries.GetAll;

public sealed record GetAllSkillsResponse
    (int Id, string Name, string Description, Level Level);