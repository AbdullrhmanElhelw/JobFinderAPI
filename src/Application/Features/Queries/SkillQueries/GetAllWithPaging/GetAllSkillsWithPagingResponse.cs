using Domain.Enums.SkillLevels;

namespace Application.Features.Queries.SkillQueries.GetAllWithPaging;

public sealed record GetAllSkillsWithPagingResponse
   (int Id, string Name, string Description, Level Level);