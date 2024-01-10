using Application.Abstractions;
using Domain.Common.IdentityUsers;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Features.Commands.AdminCommands.AdminLogout
{
    public sealed class AdminLogoutCommandHandler(UserManager<Admin> userManager) : ICommandHandler<AdminLogoutCommand>
    {
        public async Task<Result> Handle(AdminLogoutCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.AdminId.ToString());

            if (user is null)
                return Result.Fail("Admin not found");

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenValid = tokenHandler.CanReadToken(request.AdminToken);

            if (!tokenValid)
                return Result.Fail("Invalid token");

            var logoutResult = await userManager.RemoveAuthenticationTokenAsync(user, "Default", "Logout");

            if (!logoutResult.Succeeded)
                return Result.Fail($"Logout failed: {string.Join(", ", logoutResult.Errors)}");

            return Result.Ok("Logout successful");
        }
    }
}