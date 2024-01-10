using Application.Abstractions;
using Application.EmailServices;
using Application.Templates;
using Domain.Common.IdentityUsers;
using Domain.Enums.ApplicationRoles;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.CompanyCommands.CompanyRegistration;

public sealed class CompanyRegistrationCommandHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
    : ICommandHandler<CompanyRegistrationCommand>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result> Handle(CompanyRegistrationCommand request, CancellationToken cancellationToken)
    {
        var company = new Company
        {
            Email = request.Email,
            UserName = request.Email.Substring(0, request.Email.IndexOf("@", StringComparison.Ordinal)),
            Name = request.Name,
            Address = request.Address,
            City = request.City,
            Country = request.Country
        };

        var createResult = await _userManager.CreateAsync(company, request.Password);

        if (!createResult.Succeeded)
            foreach (var error in createResult.Errors)
                return Result.Fail(error.Description);

        var roleResult = await _userManager.AddToRoleAsync(company, RolesEnum.Company.ToString());

        if (!roleResult.Succeeded)
            foreach (var error in roleResult.Errors)
                return Result.Fail(error.Description);

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(company);

        var confirmationLink = EmailRegistrationTemplate.GetEmailRegistrationTemplate("localhost", company.Email, token);

        await _emailService.SendEmailAsync(request.Email, "Confirm Email", confirmationLink);

        return Result.Ok();
    }
}