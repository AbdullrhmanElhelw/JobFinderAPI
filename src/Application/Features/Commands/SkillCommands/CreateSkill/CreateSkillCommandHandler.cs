using Application.Abstractions;
using Application.Interfaces.UnitOfWork;
using Domain.Models;
using Domain.Shared;

namespace Application.Features.Commands.SkillCommands.CreateSkill;

public sealed class CreateSkillCommandHandler(IUnitOfWork unitOfWork)
   : ICommandHandler<CreateSkillCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = new Skill
        {
            Name = request.Name,
            Description = request.Description,
            Level = request.Level
        };

        await _unitOfWork.SkillRepository.AddAsync(skill);

        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail(new Error("Saving Error"));

        return Result.Ok();
    }
}