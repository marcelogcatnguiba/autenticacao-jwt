namespace AuthSample.Api.Controller.Context;

public static class AuthAppContext
{
    public static List<Usuario> Usuarios { get => UsuariosIniciais(); }

    public static List<Usuario> UsuariosIniciais()
    {
        return 
        [
            new("admin@email.com", "123")
        ];
    }
}

public record Usuario(string Email, string Senha);
