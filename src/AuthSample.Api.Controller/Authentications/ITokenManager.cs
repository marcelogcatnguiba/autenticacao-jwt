using AuthSample.Api.Controller.Context;

namespace AuthSample.Api.Controller.Authentications;

public interface ITokenManager
{
    string GenerateToken(Usuario user);
}
