using MeuLivroDeReceitas.Domain.Repositories;
using MeuLivroDeReceitas.Infrastructure.Context;

namespace MeuLivroDeReceitas.Infrastructure;

public sealed class Uow : IDisposable, IUow
{
    private readonly AppDbContext _context;

    private bool _disposed;

    public Uow(AppDbContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed && disposing)
            _context.Dispose();

        _disposed = disposing;
    }
}
