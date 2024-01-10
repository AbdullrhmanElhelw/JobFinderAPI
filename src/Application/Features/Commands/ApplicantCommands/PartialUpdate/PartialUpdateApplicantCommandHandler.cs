using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.ApplicantCommands.PartialUpdate;

public sealed class PartialUpdateApplicantCommandHandler(UserManager<Applicant> userManager)
    : ICommandHandler<PartialUpdateApplicantCommand>
{
    private readonly UserManager<Applicant> _userManager = userManager;

    public async Task<Result> Handle(PartialUpdateApplicantCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.Email);

        if (userExists is null)
            return Result.Fail("User does not exist");

        request.ApplicantPD.ApplyTo(userExists);

        var result = await _userManager.UpdateAsync(userExists);

        if (!result.Succeeded)
            return Result.Fail("Failed to update user");

        return Result.Ok();
    }
}