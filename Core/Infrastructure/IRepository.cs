using System.Linq.Expressions;
using Core.Domain.Abstract;

namespace Core.Infrastructure;

public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity, new() { }

public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
{
    TEntity Get(TKey id);
    TEntity GetAsync(TKey id, CancellationToken cancellationToken);

    TEntity Get(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    List<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    TEntity Add(TEntity entity);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

    TEntity Update(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    void Delete(TEntity entity);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    void Delete(Expression<Func<TEntity, bool>> predicate);
    Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    int Count(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
}