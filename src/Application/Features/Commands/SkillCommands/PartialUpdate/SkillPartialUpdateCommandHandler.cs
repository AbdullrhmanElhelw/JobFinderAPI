using Application.Abstractions;
using Application.DapperQueries.SKillQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Shared;

namespace Application.Features.Commands.SkillCommands.PartialUpdate;

public sealed class SkillPartialUpdateCommandHandler(IUnitOfWork unitOfWork, ISkillQuery skillQuery)
    : ICommandHandler<SkillPartialUpdateCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ISkillQuery _skillQuery = skillQuery;

    public async Task<Result> Handle(SkillPartialUpdateCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillQuery.Get(request.Id);

        if (skill is null)
            return Result.Fail("Skill not found");

        request.SkillPD.ApplyTo(skill);

        _unitOfWork.SkillRepository.UpdateAsync(skill);

        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail("Failed to update skill");

        return Result.Ok();
    }
}