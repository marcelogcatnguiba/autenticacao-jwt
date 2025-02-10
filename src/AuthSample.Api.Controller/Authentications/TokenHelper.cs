using AuthSample.Api.Controller.Settings;

namespace AuthSample.Api.Controller.Authentications;

public static class TokenHelper
{
    public static TokenValidationParameters GetTokenValidationParameters()
    {
        var jwtSettings = Configuration.JwtSettings;
        var tokenKey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

        return new()
        {
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,

            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,

            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(tokenKey)
        };
    }
}
