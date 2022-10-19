using Domain.Entities;

namespace Application.Abstract;

public interface ICategoryService
{
    Task AddAsync(Category category, CancellationToken cancellationToken);
    Task UpdateAsync(Category category, CancellationToken cancellationToken);
    Task<Category?> GetAsync(int id, CancellationToken cancellationToken);
}