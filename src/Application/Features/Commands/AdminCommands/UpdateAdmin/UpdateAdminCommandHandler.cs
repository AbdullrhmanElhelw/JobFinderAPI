using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AdminCommands.UpdateAdmin;

public sealed class UpdateAdminCommandHandler(UserManager<Admin> userManager)
    : ICommandHandler<UpdateAdminCommand>
{
    private readonly UserManager<Admin> _userManager = userManager;

    public async Task<Result> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByIdAsync(request.Id.ToString());

        if (userExists is null)
            return Result.Fail("User does not exist");

        userExists!.FirstName = request.FirstName;
        userExists.LastName = request.LastName;

        var result = await _userManager.UpdateAsync(userExists);

        return result.Succeeded ?
            Result.Ok() :
            Result.Fail("Failed to update user");
    }
}