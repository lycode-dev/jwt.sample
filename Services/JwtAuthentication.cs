using ly.jwt.Services.Contracts;
using ly.jwt.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace ly.jwt.Services;

public class JwtAuthentication: IJwtAuthentication
{
    private readonly IConfiguration _config;

    public JwtAuthentication(IConfiguration config)
    {
        _config = config;
    }

    // Generar Token
    public string GetToken(User user)
    {
        // Obtener key y encriptarlo con SHA256
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Crear los claims
        var claims = new[]
        {
            new Claim("Username", user.Username),
            new Claim(ClaimTypes.Role, user.Role),
        };

        // Crear el token
        var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
