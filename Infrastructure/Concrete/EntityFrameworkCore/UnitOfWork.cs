using Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Concrete.EntityFrameworkCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public UnitOfWork(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(DbContext));
    }

    public int SaveChanges() => _context.SaveChanges();

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}