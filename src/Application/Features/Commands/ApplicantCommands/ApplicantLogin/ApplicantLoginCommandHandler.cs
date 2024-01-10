using Application.Abstractions;
using Application.Interfaces.TokenProvider;
using Domain.Common.IdentityUsers;
using Domain.Enums.ApplicationRoles;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Features.Commands.ApplicantCommands.ApplicantLogin;

public sealed class ApplicantLoginCommandHandler(UserManager<ApplicationUser> userManager, ITokenGenerator tokenGenerator)
    : ICommandHandler<ApplicantLoginCommand, string>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

    public async Task<Result<string>> Handle(ApplicantLoginCommand request, CancellationToken cancellationToken)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        var userByUserName = await _userManager.FindByNameAsync(request.Email);
        var user = userByEmail ?? userByUserName;

        if (user is null)
            return Result.Fail<string>("User not found");

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!passwordValid)
            return Result.Fail<string>("Invalid password");

        if (!user.EmailConfirmed)
            return Result.Fail<string>("Email not confirmed");

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new(ClaimTypes.Email, user.Email!),
            new(ClaimTypes.Role,nameof(RolesEnum.Applicant))
        };

        var token = _tokenGenerator.GenerateToken(claims);

        return Result.Ok(token);
    }
}