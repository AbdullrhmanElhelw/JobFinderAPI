using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AdminCommands.DeleteAdmin;

public sealed class DeleteAdminCommandHandler(UserManager<Admin> userManager)
    : ICommandHandler<DeleteAdminCommand>
{
    private readonly UserManager<Admin> _userManager = userManager;

    public async Task<Result> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = await _userManager.FindByIdAsync(request.Id.ToString());
        if (admin is null)
            return Result.Fail("Admin not found");

        var result = await _userManager.DeleteAsync(admin);
        if (!result.Succeeded)
            return Result.Fail("Failed to delete admin");

        return Result.Ok("Admin Deleted Successfully");
    }
}