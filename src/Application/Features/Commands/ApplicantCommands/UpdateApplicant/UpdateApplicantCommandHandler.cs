using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.ApplicantCommands.UpdateApplicant;

public sealed class UpdateApplicantCommandHandler(UserManager<Applicant> userManager)
    : ICommandHandler<UpdateApplicantCommand>
{
    private readonly UserManager<Applicant> _userManager = userManager;

    public async Task<Result> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        if (user is null)
        {
            return Result.Fail("User not found");
        }
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded
            ? Result.Ok()
            : Result.Fail("Failed to update user");
    }
}