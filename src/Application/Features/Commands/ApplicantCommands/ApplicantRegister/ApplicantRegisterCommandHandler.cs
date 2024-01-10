using Application.Abstractions;
using Application.EmailServices;
using Application.Templates;
using Domain.Common.IdentityUsers;
using Domain.Enums.ApplicationRoles;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.ApplicantCommands.ApplicantRegister;

public sealed class ApplicantRegisterCommandHandler(UserManager<Applicant> userManager, IEmailService emailService)
    : ICommandHandler<ApplicantRegisterCommand>
{
    private readonly UserManager<Applicant> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result> Handle(ApplicantRegisterCommand request, CancellationToken cancellationToken)
    {
        var applicant = new Applicant
        {
            Email = request.Email,
            UserName = request.Email.Substring(0, request.Email.IndexOf("@", StringComparison.Ordinal)),
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var createResult = await _userManager.CreateAsync(applicant, request.Password);

        if (!createResult.Succeeded)
            foreach (var error in createResult.Errors)
                return Result.Fail(error.Description);

        var roleResult = await _userManager.AddToRoleAsync(applicant, RolesEnum.Applicant.ToString());

        if (!roleResult.Succeeded)
            foreach (var error in roleResult.Errors)
                return Result.Fail(error.Description);

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(applicant);

        var confirmationLink = EmailRegistrationTemplate.GetEmailRegistrationTemplate
            (request.Origin, applicant.Email, token);

        await _emailService.SendEmailAsync(applicant.Email, "Confirm Email", confirmationLink);

        return Result.Ok();
    }
}