using AuthSample.Api.Controller.Settings;

namespace AuthSample.Api.Controller.Authentications;

public class TokenManager : ITokenManager
{
    public string GenerateToken(Usuario user)
    {
        var jwtSettings = Configuration.JwtSettings;
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

        var claims = new List<Claim>()
        {
            new (JwtRegisteredClaimNames.Sub, user.Email),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            new(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken
        (
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims:  claims,
            expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationTimeInMinutes),
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}