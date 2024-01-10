using Application.Abstractions;
using Application.EmailServices;
using Domain.Common.IdentityUsers;
using Domain.Enums.ApplicationRoles;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.EmployerCommands.EmployerRegister;

public sealed class EmployerRegisterCommandHandler(UserManager<Employer> userManager, IEmailService emailService)
    : ICommandHandler<EmployerRegisterCommand>
{
    private readonly UserManager<Employer> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result> Handle(EmployerRegisterCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.Email);
        if (userExists != null)
            return Result.Fail($"User with email {request.Email} already exists");

        var employer = new Employer
        {
            Email = request.Email,
            UserName = request.Email.Substring(0, request.Email.IndexOf("@", StringComparison.Ordinal)),
            FirstName = request.FirstName,
            LastName = request.LastName,
            CompanyId = request.CompanyId
        };

        var result = await _userManager.CreateAsync(employer, request.Password);

        if (!result.Succeeded)
            foreach (var error in result.Errors)
                return Result.Fail(error.Description);

        var roleResult = await _userManager.AddToRoleAsync(employer, nameof(RolesEnum.Employer));
        if (!roleResult.Succeeded)
            foreach (var error in roleResult.Errors)
                return Result.Fail(error.Description);

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(employer);

        await _emailService.SendEmailAsync(employer.Email, "Confirm your email",
                       $"Please confirm your account by clicking this link: <a href='https://localhost:7249/api/Email/ConfirmEmail?email={employer.Email}&token={token}'>link</a>");

        return Result.Ok();
    }
}