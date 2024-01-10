using Application.Abstractions;
using Application.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Shared;

namespace Application.Features.Commands.SkillCommands.CreateMultiSkills;

public sealed class CreateMultiSkillsCommandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateMultiSkillsCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateMultiSkillsCommand request, CancellationToken cancellationToken)
    {
        var skills = request.Skills.Select(skill => new Skill
        {
            Name = skill.Name,
            Description = skill.Description,
            Level = skill.Level
        });

        await _unitOfWork.SkillRepository.AddRangeAsync(skills);

        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail(new Error("Saving Error"));

        return Result.Ok();
    }
}