using Application.Abstractions;
using Application.EmailServices;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.EmailCommands.ConfirmUpdatedEmail;

public sealed class ConfirmUpdatedEmailCommandHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
    : ICommandHandler<ConfirmUpdatedEmailCommand>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result> Handle(ConfirmUpdatedEmailCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.OldEmail);

        if (userExists is null)
            return Result.Fail("User does not exist");

        var verifyToken = await _userManager.VerifyUserTokenAsync
            (userExists, _userManager.Options.Tokens.ChangeEmailTokenProvider, "ChangeEmail", request.Token);

        if (!verifyToken)
            return Result.Fail("Invalid token");

        var result = await _userManager.ChangeEmailAsync(userExists, request.Email, request.Token);

        if (!result.Succeeded)
            return Result.Fail("Failed to change email");

        await _emailService.SendEmailAsync(request.Email, "Email Changed", "Your email has been changed");

        return Result.Ok();
    }
}