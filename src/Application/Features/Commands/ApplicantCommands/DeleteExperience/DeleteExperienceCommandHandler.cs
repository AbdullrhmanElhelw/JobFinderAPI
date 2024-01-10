using Application.Abstractions;
using Application.Interfaces.UnitOfWork;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.ApplicantCommands.DeleteExperience;

public sealed class DeleteExperienceCommandHandler(IUnitOfWork unitOfWork, UserManager<Applicant> userManager)
    : ICommandHandler<DeleteExperienceCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly UserManager<Applicant> _userManager = userManager;

    public async Task<Result> Handle(DeleteExperienceCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByIdAsync(request.ApplicantId.ToString());
        if (userExists is null)
            return Result.Fail("User does not exist");

        var findExperience = await _unitOfWork.ExperienceRepository.GetByIdAsync(request.ExperinceId);
        if (findExperience is null)
            return Result.Fail("Experience does not exist");

        await _unitOfWork.ExperienceRepository.DeleteAsync(findExperience);
        if (await _unitOfWork.CommitAsync() == 0)
            return Result.Fail("Failed to delete experience");

        return Result.Ok("Experience deleted successfully");
    }
}