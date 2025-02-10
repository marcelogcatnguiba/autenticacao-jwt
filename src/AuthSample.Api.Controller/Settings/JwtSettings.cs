namespace AuthSample.Api.Controller.Settings;

public class JwtSettings
{
    public const string Section = "JwtSettings";

    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpirationTimeInMinutes { get; set; }
    public int RefreshTokenExpirationTimeInMinutes { get; set; }
}
