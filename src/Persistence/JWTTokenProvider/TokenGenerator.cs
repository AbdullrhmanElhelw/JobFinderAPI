using Application.Interfaces.TokenProvider;
using Domain.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Persistence.JWTTokenProvider;

public class TokenGenerator(IOptions<JWTSettings> options)
    : ITokenGenerator
{
    private readonly JWTSettings _jwtSettings = options.Value;

    public string GenerateToken(List<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.DurationInMinutes));
        var token = new JwtSecurityToken(
                    _jwtSettings.Issuer,
                    _jwtSettings.Issuer,
                    claims,
                    expires: expires,
                    signingCredentials: creds
                    );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}