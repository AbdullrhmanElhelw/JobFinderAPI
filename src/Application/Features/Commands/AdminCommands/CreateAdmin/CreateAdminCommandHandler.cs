using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Enums.ApplicationRoles;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AdminCommands.CreateAdmin;

public sealed class CreateAdminCommandHandler(UserManager<Admin> userManager)
    : ICommandHandler<CreateAdminCommand>
{
    private readonly UserManager<Admin> _userManager = userManager;

    public async Task<Result> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var user = new Admin
        {
            UserName = request.Email.Substring(0, request.Email.IndexOf("@", StringComparison.Ordinal)),
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        var createResult = await _userManager.CreateAsync(user, request.Password);

        if (!createResult.Succeeded)
            foreach (var error in createResult.Errors)
                return Result.Fail(error.Description);

        var addToRoleResult = await _userManager.AddToRoleAsync(user, nameof(RolesEnum.Admin));

        if (!addToRoleResult.Succeeded)
            foreach (var error in addToRoleResult.Errors)
                return Result.Fail(error.Description);

        await _userManager.ConfirmEmailAsync(user, await _userManager.GenerateEmailConfirmationTokenAsync(user));
        return Result.Ok();
    }
}