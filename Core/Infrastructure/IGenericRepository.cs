using System.Linq.Expressions;
using Core.Domain.Abstract;

namespace Core.Infrastructure;

public interface IGenericRepository<TEntity> : IGenericRepository<TEntity, int> where TEntity : class, IEntity, new() { }

public interface IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
{
    TEntity? Get(TKey id);
    Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken);

    TEntity? Get(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    List<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    void Add(TEntity entity);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    int Count(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
}