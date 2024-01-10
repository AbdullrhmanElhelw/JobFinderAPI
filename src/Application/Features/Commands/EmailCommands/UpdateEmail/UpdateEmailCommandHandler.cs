using Application.Abstractions;
using Application.EmailServices;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.EmailCommands.UpdateEmail;

public sealed class UpdateEmailCommandHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
    : ICommandHandler<UpdateEmailCommand>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.Email);

        if (userExists is null)
            return Result.Fail("User does not exist");

        var verifyPassword = await _userManager.CheckPasswordAsync(userExists, request.Password);

        if (!verifyPassword)
            return Result.Fail("Invalid password");

        var newEmailExists = await _userManager.FindByEmailAsync(request.NewEmail);
        if (newEmailExists is not null)
            return Result.Fail("New email already exists");

        var generateToken = await _userManager.GenerateChangeEmailTokenAsync(userExists, request.NewEmail);

        if (generateToken is null)
            return Result.Fail("Failed to generate token");

        await _emailService.SendEmailAsync(request.NewEmail, "Confirm Email", $"Confirm your email by clicking this link:/api/Email/ConfirmEmail?email={request.NewEmail}&token={generateToken}");

        return Result.Ok();
    }
}