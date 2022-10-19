using Domain.Entities;

namespace Infrastructure.Abstract;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetMostExpensiveProductsAsync(int count, CancellationToken cancellationToken);
    Task<List<Product>> GetProductsAsync(int page, int pageSize, CancellationToken cancellationToken);
}