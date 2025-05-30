using System.Text;
using Back.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
namespace Back.Services;

public class JwtService : IJwtService
{
    private readonly string SecretKey;
    private readonly int ExpireHours;

    public JwtService(IOptions<JwtSettings> jwtSettings)
    {
        var settings = jwtSettings.Value;
        SecretKey = settings.SecretKey;
        ExpireHours = settings.ExpireHours;
    }
    public string GenerateToken(UserEntity user)
    {
        Claim[] claims = { new Claim("userId", user.Id.ToString()) };

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
        SecurityAlgorithms.HmacSha256);

        var Token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(ExpireHours)
        );
        var TokenValue = new JwtSecurityTokenHandler().WriteToken(Token);
        return TokenValue;
    }
}