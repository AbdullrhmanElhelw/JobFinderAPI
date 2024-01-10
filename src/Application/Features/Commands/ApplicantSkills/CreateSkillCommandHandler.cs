using Application.Abstractions;
using Application.DapperQueries.ApplicantQueries;
using Application.DapperQueries.SKillQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Shared;

namespace Application.Features.Commands.ApplicantSkills;

public sealed class CreateSkillCommandHandler(IUnitOfWork unitOfWork, IApplicantQuery applicantQuery, ISkillQuery skillQuery)
    : ICommandHandler<CreateSkillCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IApplicantQuery _applicantQuery = applicantQuery;
    private readonly ISkillQuery _skillQuery = skillQuery;

    public async Task<Result> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var applicant = await _applicantQuery.Get(request.ApplicantId);
        if (applicant is null)
            return Result.Fail("User " + Error.NotFound);

        var skill = await _skillQuery.Get(request.SkillId);
        if (skill is null)
            return Result.Fail("Skill " + Error.NotFound);

        var applicantSkill = new ApplicantSkill
        {
            ApplicantId = request.ApplicantId,
            SkillId = request.SkillId
        };

        await _unitOfWork.ApplicantSkillRepository.AddAsync(applicantSkill);
        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail(new Error("Saving Error"));

        return Result.Ok();
    }
}
