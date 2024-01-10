using Application.Abstractions;
using Application.Features.Commands.EmailCommands.ComfirmEmail;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.EmailCommands.ConfirmEmail;

public sealed class ConfirmEmailCommandHandler(UserManager<ApplicationUser> userManager)
    : ICommandHandler<ConfirmEmailCommand>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.Email);
        if (userExists is null)
            return Result.Fail("User does not exist");

        var confirmEmailResult = await _userManager.ConfirmEmailAsync(userExists, request.Token);

        return confirmEmailResult.Succeeded
            ? Result.Ok()
            : Result.Fail("Email Confirmation Failed");
    }
}