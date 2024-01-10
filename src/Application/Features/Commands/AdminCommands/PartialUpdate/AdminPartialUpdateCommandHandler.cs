using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AdminCommands.PartialUpdate;

public sealed class AdminPartialUpdateCommandHandler(UserManager<Admin> userManager)
    : ICommandHandler<AdminPartialUpdateCommand>
{
    private readonly UserManager<Admin> _userManager = userManager;

    public async Task<Result> Handle(AdminPartialUpdateCommand request, CancellationToken cancellationToken)
    {
        var admin = await _userManager.FindByEmailAsync(request.Email);

        if (admin is null)
            return Result.Fail("Admin not found.");

        request.AdminPD.ApplyTo(admin);

        var result = await _userManager.UpdateAsync(admin);

        return result.Succeeded ?
            Result.Ok() :
            Result.Fail("Admin update failed.");
    }
}