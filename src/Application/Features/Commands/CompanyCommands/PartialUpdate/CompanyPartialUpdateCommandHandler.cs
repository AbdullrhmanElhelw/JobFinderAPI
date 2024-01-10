using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.CompanyCommands.PartialUpdate;

public sealed record CompanyPartialUpdateCommandHandler(UserManager<Company> userManager)
    : ICommandHandler<CompanyPartialUpdateCommand>
{
    private readonly UserManager<Company> _userManager = userManager;
    public async Task<Result> Handle(CompanyPartialUpdateCommand request, CancellationToken cancellationToken)
    {
        var companyExists = await _userManager.FindByEmailAsync(request.Email);
        if (companyExists is null)
            return Result.Fail("Company not found");

        request.CompanyPD.ApplyTo(companyExists);

        var result = await _userManager.UpdateAsync(companyExists);

        return result.Succeeded ?
            Result.Ok() :
            Result.Fail("Company update failed");
    }
}