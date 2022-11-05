using MeuLivroDeReceitas.Domain.Entities;

namespace MeuLivroDeReceitas.Domain.Repositories;

public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
