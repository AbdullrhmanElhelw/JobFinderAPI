using Application.Abstractions;

namespace Application.Features.Queries.SkillQueries.GetById;

public sealed record GetSkillByIdQuery
   (int Id) : IQuery<GetSkillByIdResponse>;