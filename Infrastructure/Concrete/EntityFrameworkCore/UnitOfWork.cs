using Infrastructure.Abstract;
using Infrastructure.Concrete.EntityFrameworkCore.Contexts;
using Infrastructure.Concrete.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Concrete.EntityFrameworkCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(DbContext));
        Categories = new CategoryRepository(_context);
        Products = new ProductRepository(_context);
        ProductFeatures = new ProductFeatureRepository(_context);
    }

    public ICategoryRepository Categories { get; private set; }
    public IProductRepository Products { get; private set; }
    public IProductFeatureRepository ProductFeatures { get; private set; }

    public int SaveChanges() => _context.SaveChanges();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);

    public void Dispose() => _context.Dispose();
    public async ValueTask DisposeAsync() => await _context.DisposeAsync();
}