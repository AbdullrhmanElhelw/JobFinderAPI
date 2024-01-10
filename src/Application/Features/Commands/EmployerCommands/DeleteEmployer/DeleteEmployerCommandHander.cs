using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.EmployerCommands.DeleteEmployer;

public sealed class DeleteEmployerCommandHander(UserManager<Employer> userManager)
    : ICommandHandler<DeleteEmployerCommand>
{
    private readonly UserManager<Employer> _userManager = userManager;

    public async Task<Result> Handle(DeleteEmployerCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByIdAsync(request.Id.ToString());
        if (userExists is null)
            return Result.Fail("User does not exist");

        var result = await _userManager.DeleteAsync(userExists);
        return result.Succeeded
            ? Result.Ok()
            : Result.Fail("Failed to delete user");
    }
}