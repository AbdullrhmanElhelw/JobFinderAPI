using Application.Abstractions;
using Application.DapperQueries.SKillQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Shared;

namespace Application.Features.Commands.SkillCommands.UpdateSkill;

public sealed class UpdateSkillCommandHandler(IUnitOfWork unitOfWork, ISkillQuery skillQuery)
    : ICommandHandler<UpdateSkillCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ISkillQuery _skillQuery = skillQuery;

    public async Task<Result> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillQuery.Get(request.Id);
        if (skill is null)
            return Result.Fail("Skill not found");

        skill.Name = request.Name;
        skill.Description = request.Description;

        _unitOfWork.SkillRepository.UpdateAsync(skill);

        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail("Failed to update skill");

        return Result.Ok("Skill updated successfully");
    }
}