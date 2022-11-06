namespace MeuLivroDeReceitas.Comunicacao.UseCases.User.Request;

public class CreateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
}
