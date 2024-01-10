using Application.Abstractions;

namespace Application.Features.Queries.ApplicantQueries.GetApplicantSkills;

public record GetApplicantSkillQuery
    (int ApplicantId) : IQuery<IQueryable<GetApplicantSkillResponse>>;
