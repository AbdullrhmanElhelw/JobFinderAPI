using Application.Abstractions;
using Application.Interfaces.TokenProvider;
using Domain.Common.IdentityUsers;
using Domain.Enums.ApplicationRoles;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Features.Commands.EmployerCommands.EmployerLogin;

public sealed class EmployerLoginCommandHandler(UserManager<Employer> userManager, ITokenGenerator tokenGenerator)
    : ICommandHandler<EmployerLoginCommand>
{
    private readonly UserManager<Employer> _userManager = userManager;

    public async Task<Result> Handle(EmployerLoginCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.Email);
        if (userExists is null)
            return Result.Fail("User does not exist");

        var passwordValid = await _userManager.CheckPasswordAsync(userExists, request.Password);
        if (!passwordValid)
            return Result.Fail("Password is incorrect");

        var confirmEmail = await _userManager.IsEmailConfirmedAsync(userExists);
        if (!confirmEmail)
            return Result.Fail("Email is not confirmed");

        var claims = new List<Claim>
        {
           new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Email, userExists.Email!),
            new(ClaimTypes.Role, nameof(RolesEnum.Employer))
        };

        var token = tokenGenerator.GenerateToken(claims);

        return Result.Ok(token);
    }
}