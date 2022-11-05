namespace MeuLivroDeReceitas.Domain.Repositories;

public interface IUserReadOnlyRepository
{
    Task<bool> Exists(string email);
}
