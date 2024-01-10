using Application.Abstractions;
using Application.DapperQueries.ApplicantQueries;
using Application.DapperQueries.ApplicantSkillQueries;
using Application.DapperQueries.SKillQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Shared;

namespace Application.Features.Commands.ApplicantCommands.DeleteSkill;

public sealed class DeleteSkillCommandHandler
    (IUnitOfWork unitOfWork, IApplicantQuery applicantQuery, ISkillQuery skillQuery, IApplicantSkillQuery applicantSkillQuery)
    : ICommandHandler<DeleteApplicantSkillCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IApplicantQuery _applicantQuery = applicantQuery;
    private readonly ISkillQuery _skillQuery = skillQuery;
    private readonly IApplicantSkillQuery _applicantSkillQuery = applicantSkillQuery;
    public async Task<Result> Handle(DeleteApplicantSkillCommand request, CancellationToken cancellationToken)
    {
        var applicant = await _applicantQuery.Get(request.ApplicantId);

        if (applicant is null)
            return Result.Fail(Error.NotFound);

        var skill = await _skillQuery.Get(request.SkillId);
        if (skill is null)
            return Result.Fail(Error.NotFound);

        var applicantSkill = _applicantSkillQuery.GetApplicantSkill(request.ApplicantId, request.SkillId);
        if (applicantSkill is null)
            return Result.Fail(Error.NotFound);

        var applicantSkillEntity = new ApplicantSkill
        {
            ApplicantId = request.ApplicantId,
            SkillId = request.SkillId
        };

        await _unitOfWork.ApplicantSkillRepository.DeleteAsync(applicantSkillEntity);
        await _unitOfWork.CommitAsync();
        return Result.Ok();
    }
}
