using Application.Abstractions;

namespace Application.Features.Queries.SkillQueries.GetAll;

public sealed class GetAllSkillQuery
    () : IQuery<IQueryable<GetAllSkillsResponse>>;