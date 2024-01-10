using Application.Abstractions;
using Application.Interfaces.TokenProvider;
using Domain.Common.IdentityUsers;
using Domain.Enums.ApplicationRoles;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Features.Commands.CompanyCommands.CompanyLogin;

public sealed class CompanyLoginCommandHandler
    (UserManager<ApplicationUser> userManager, ITokenGenerator tokenGenerator)
    : ICommandHandler<CompanyLoginCommand, string>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

    public async Task<Result<string>> Handle(CompanyLoginCommand request, CancellationToken cancellationToken)
    {
        var byEmail = await _userManager.FindByEmailAsync(request.Email);
        var byUserName = await _userManager.FindByNameAsync(request.Email);

        var user = byEmail ?? byUserName;

        if (user is null)
            return Result.Fail<string>(Error.NotFound);

        var checkPassword = _userManager.CheckPasswordAsync(user, request.Password).Result;

        if (!checkPassword)
            return Result.Fail<string>(Error.Invalid + "Password");

        var claims = new List<Claim>
        {
           new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new(ClaimTypes.Name, user.UserName!),
            new(ClaimTypes.Email, user.Email!),
            new(ClaimTypes.Role, nameof(RolesEnum.Company))
        };

        var token = _tokenGenerator.GenerateToken(claims);

        return Result.Ok(token);
    }
}