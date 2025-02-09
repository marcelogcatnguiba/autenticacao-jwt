namespace AuthSample.Api.Controller.Authentications;

public class TokenManager(IConfiguration configuration) : ITokenManager
{
    private readonly IConfiguration _configuration = configuration;

    public string GenerateToken(Usuario user)
    {
        //Informacoes importantes
        //Tempo de vida - ExpirationTime
        //Emissor - Issuer
        //Audiencia - Audience
        //Chave secreta - SecretKey

        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? string.Empty));

        // Informacoes do token
        var claims = new List<Claim>()
        {
            new (JwtRegisteredClaimNames.Sub, user.Email),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            //Roles de usuarios
            new(ClaimTypes.Role, user.Role)
        };

        var tempoExpiracao = jwtSettings.GetValue<int>("ExpirationTimeInMinutes");

        // Montando o token
        var token = new JwtSecurityToken
        (
            issuer: jwtSettings.GetValue<string>("Issuer"), // Quem emite
            audience: jwtSettings.GetValue<string>("Audience"), // Quem consome
            claims:  claims,
            expires: DateTime.UtcNow.AddMinutes(tempoExpiracao),
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
