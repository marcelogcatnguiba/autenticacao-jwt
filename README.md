```csharp
using AuthSample.Api.Controller.Settings;

namespace AuthSample.Api.Controller.Authentications;

public class TokenManager : ITokenManager
{
    public string GenerateToken(Usuario user)
    {
        //Informacoes importantes
        //Tempo de vida - ExpirationTime
        //Emissor - Issuer
        //Audiencia - Audience
        //Chave secreta - SecretKey

        var jwtSettings = Configuration.JwtSettings;
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

        // Informacoes do token
        var claims = new List<Claim>()
        {
            new (JwtRegisteredClaimNames.Sub, user.Email),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            //Roles de usuarios
            new(ClaimTypes.Role, user.Role)
        };

        // Montando o token
        var token = new JwtSecurityToken
        (
            issuer: jwtSettings.Issuer, // Quem emite
            audience: jwtSettings.Audience, // Quem consome
            claims:  claims,
            expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationTimeInMinutes),
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

```