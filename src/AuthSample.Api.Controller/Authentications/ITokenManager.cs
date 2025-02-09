namespace AuthSample.Api.Controller.Authentications;

public interface ITokenManager
{
    string GenerateToken(Usuario user);
}
