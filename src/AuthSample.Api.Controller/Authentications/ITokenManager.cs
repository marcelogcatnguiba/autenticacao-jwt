namespace AuthSample.Api.Controller.Authentications;

public interface ITokenManager
{
    string GenerateToken(Usuario user);
    string GenerateRefreshToken(Usuario user);
    Task<(bool isValid, string email)> ValidateTokenAsync(string refreshToken);
}
