using System.Security.Claims;

namespace Application.Interfaces.TokenProvider;

public interface ITokenGenerator
{
    string GenerateToken(List<Claim> claims);
}