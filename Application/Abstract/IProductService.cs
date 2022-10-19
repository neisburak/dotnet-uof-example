using Domain.Entities;

namespace Application.Abstract;

public interface IProductService
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
    Task UpdateAsync(Product product, CancellationToken cancellationToken);
    Task<Product?> GetAsync(int id, CancellationToken cancellationToken);
    Task<List<Product>> GetAsync(int page, int pageSize, CancellationToken cancellationToken);
    Task<List<Product>> GetMostExpensivesAsync(CancellationToken cancellationToken);
}