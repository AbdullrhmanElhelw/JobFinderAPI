using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.CompanyCommands.UpdateCompany;

public sealed class UpdateCompanyCommandHandler(UserManager<Company> userManager)
    : ICommandHandler<UpdateCompanyCommand>
{
    private readonly UserManager<Company> _userManager = userManager;

    public async Task<Result> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var companyExists = await _userManager.FindByIdAsync(request.Id.ToString());
        if (companyExists is null)
            return Result.Fail("Company does not exist.");

        companyExists.Name = request.Name;
        companyExists.Address = request.Address;
        companyExists.City = request.City;

        var updateResult = await _userManager.UpdateAsync(companyExists);
        if (!updateResult.Succeeded)
            return Result.Fail("Failed to update company.");

        return Result.Ok("Company Updated Successfully!");
    }
}