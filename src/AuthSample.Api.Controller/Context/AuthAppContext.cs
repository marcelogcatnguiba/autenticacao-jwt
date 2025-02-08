namespace AuthSample.Api.Controller.Context;

public static class AuthAppContext
{
    public const string ROLE_ADMIN = "Administrador";
    public const string ROLE_COMUM = "Comum";
    
    public static List<Usuario> Usuarios { get => UsuariosIniciais(); }

    public static List<Usuario> UsuariosIniciais()
    {
        return 
        [
            new("admin@email.com", "123", ROLE_ADMIN)
        ];
    }
}

public record Usuario(string Email, string Senha, string Role);
