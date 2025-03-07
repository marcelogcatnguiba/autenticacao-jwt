namespace AuthSample.Api.Controller.Context;

public static class AuthAppContext
{    
    public static List<Usuario> Usuarios { get => UsuariosIniciais(); }

    public static List<Usuario> UsuariosIniciais()
    {
        return 
        [
            new("admin", "admin", Usuario.Administrador)
        ];
    }
}