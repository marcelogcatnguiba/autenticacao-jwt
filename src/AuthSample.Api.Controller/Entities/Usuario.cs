namespace AuthSample.Api.Controller.Entities;

public record Usuario(string Email, string Senha, string Role)
{
    public const string Administrador = "Administrador";
    public const string Comum = "Comum";
};
