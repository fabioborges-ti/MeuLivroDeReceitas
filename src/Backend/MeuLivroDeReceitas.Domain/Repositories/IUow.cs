namespace MeuLivroDeReceitas.Domain.Repositories;

public interface IUow
{
    Task Commit();
}
