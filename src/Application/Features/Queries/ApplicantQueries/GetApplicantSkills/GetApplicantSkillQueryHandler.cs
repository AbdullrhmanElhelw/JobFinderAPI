using Application.Abstractions;
using Application.DapperQueries.ApplicantQueries;
using Application.DapperQueries.SKillQueries;
using Domain.Shared;

namespace Application.Features.Queries.ApplicantQueries.GetApplicantSkills;

public sealed class GetApplicantSkillQueryHandler(ISkillQuery skillQuery, IApplicantQuery applicantQuery)
    : IQueryHandler<GetApplicantSkillQuery, IQueryable<GetApplicantSkillResponse>>
{
    private readonly ISkillQuery _skillQuery = skillQuery;
    private readonly IApplicantQuery _applicantQuery = applicantQuery;

    public async Task<Result<IQueryable<GetApplicantSkillResponse>>> Handle(GetApplicantSkillQuery request, CancellationToken cancellationToken)
    {
        var applicant = await _applicantQuery.Get(request.ApplicantId);
        if (applicant is null)
            return Result.Fail<IQueryable<GetApplicantSkillResponse>>($"Applicant with id #{request.ApplicantId} not found");

        var skills = await _skillQuery.GetApplicantSkill(request.ApplicantId);
        var response = skills.Select(skill =>
             new GetApplicantSkillResponse
                 (skill.Id, skill.Name, skill.Description, skill.Level));

        return Result.Ok(response);
    }
}
