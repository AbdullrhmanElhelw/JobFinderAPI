using Application.Abstractions;
using Application.Interfaces.TokenProvider;
using Domain.Common.IdentityUsers;
using Domain.Enums.ApplicationRoles;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Features.Commands.AdminCommands.ApplicantLogin;

public sealed class AdminLoginCommandHandler(UserManager<Admin> userManager, ITokenGenerator tokenGenerator)
    : ICommandHandler<AdminLoginCommand>
{
    private readonly UserManager<Admin> _userManager = userManager;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

    public async Task<Result> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.Email);
        if (userExists is null)
            return Result.Fail("User does not exist");

        var validPassword = await _userManager.CheckPasswordAsync(userExists, request.Password);

        if (!validPassword)
            return Result.Fail("Invalid password");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, nameof(RolesEnum.Admin)),
            new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new(ClaimTypes.Email, userExists.Email!)
        };

        var token = _tokenGenerator.GenerateToken(claims);
        return Result.Ok(token);
    }
}