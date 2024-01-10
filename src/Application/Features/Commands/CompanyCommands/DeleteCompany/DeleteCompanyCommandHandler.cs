using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.CompanyCommands.DeleteCompany;

public sealed class DeleteCompanyCommandHandler(UserManager<Company> userManager)
    : ICommandHandler<DeleteCompanyCommand>
{
    private readonly UserManager<Company> _userManager = userManager;

    public async Task<Result> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _userManager.FindByIdAsync(request.Id.ToString());

        if (company is null)
            return Result.Fail("Company not found.");

        var result = await _userManager.DeleteAsync(company);
        if (!result.Succeeded)
            return Result.Fail("Failed to delete company.");

        return Result.Ok("Deleted Successfully");
    }
}