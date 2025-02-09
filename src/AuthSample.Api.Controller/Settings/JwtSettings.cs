namespace AuthSample.Api.Controller.Settings;

public class JwtSettings
{
    public const string Section = "JwtSettings";

    public static string SecretKey { get; set; } = string.Empty;
    public static string Issuer { get; set; } = string.Empty;
    public static string Audience { get; set; } = string.Empty;
    public static int ExpirationTimeInMinutes { get; set; }
    public static int RefreshTokenExpirationTimeInMinutes { get; set; }

    protected JwtSettings()
    {
        var configuration = BuildConfiguration();

        configuration.GetSection(Section).Get<JwtSettings>();
    }

    private static IConfiguration BuildConfiguration()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;

        return new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
            .AddUserSecrets("c66053c8-1891-49c0-91df-343ccf74c9f8")
            .Build();
    }
}
