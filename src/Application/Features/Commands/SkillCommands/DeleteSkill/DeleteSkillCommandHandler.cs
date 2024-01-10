using Application.Abstractions;
using Application.DapperQueries.SKillQueries;
using Application.Interfaces.UnitOfWork;
using Domain.Shared;

namespace Application.Features.Commands.SkillCommands.DeleteSkill;

public sealed class DeleteSkillCommandHandler(IUnitOfWork unitOfWork, ISkillQuery skillQuery)
    : ICommandHandler<DeleteSkillCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ISkillQuery _skillQuery = skillQuery;
    public async Task<Result> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillQuery.Get(request.Id);
        if (skill is null)
            return Result.Fail(Error.NotFound);

        await _unitOfWork.SkillRepository.DeleteAsync(skill);
        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail("Saving Error");

        return Result.Ok();
    }
}
// find skill
// delete skill
// iskillquery,
// iunitofwork