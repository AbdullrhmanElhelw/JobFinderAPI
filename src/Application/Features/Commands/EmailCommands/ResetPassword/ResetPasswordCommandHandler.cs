using Application.Abstractions;
using Application.EmailServices;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.EmailCommands.ResetPassword;

public sealed class ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
    : ICommandHandler<ResetPasswordCommand>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.Email);
        if (userExists is null)
            return Result.Fail("User does not exist");

        var oldPasswordIsValid = await _userManager.CheckPasswordAsync(userExists, request.OldPassword);

        if (!oldPasswordIsValid)
            return Result.Fail("Old password is not valid");

        var tokenIsValid = await _userManager
            .VerifyUserTokenAsync
            (userExists, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", request.Token);

        if (!tokenIsValid)
            return Result.Fail("Token is not valid");

        var result = await _userManager.ResetPasswordAsync(userExists, request.Token, request.Password);

        if (!result.Succeeded)
            return Result.Fail("Password reset failed");

        await _emailService.SendEmailAsync(request.Email, "Password Reset", "Your password has been reset");

        return Result.Ok();
    }
}

// reset password steps as code
// 1. check if user exists
// 2. check if old password is valid
// 3. check if token is valid
// 4. reset password
// 5. send email