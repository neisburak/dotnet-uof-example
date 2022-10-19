using Infrastructure.Abstract;

namespace Infrastructure;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    ICategoryRepository Categories { get; }
    IProductRepository Products { get; }
    IProductFeatureRepository ProductFeatures { get; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}