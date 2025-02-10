namespace AuthSample.Api.Controller.Settings;

public static class Configuration
{
    public static JwtSettings JwtSettings 
    { 
        get 
        {
            var configuration = BuildConfiguration();

            return configuration
                .GetSection(JwtSettings.Section)
                .Get<JwtSettings>() ?? throw new ArgumentException($"Secao invalida: {JwtSettings.Section}");
        }       
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
