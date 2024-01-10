using Application.Abstractions;
using Application.EmailServices;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.EmailCommands.SendResetPasswordEmail;

public sealed class SendResetPasswordCommandHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
    : ICommandHandler<SendResetPasswordCommand>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.Email);
        if (userExists is null)
            return Result.Fail("User does not exist");

        var token = await _userManager.GeneratePasswordResetTokenAsync(userExists);

        var callbackUrl = $"https://localhost:5001/api/ResetPassword?email={request.Email}&token={token}";

        await _emailService.SendEmailAsync(request.Email, "Reset Password", callbackUrl);

        return Result.Ok();
    }
}