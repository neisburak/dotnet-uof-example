using System.Linq.Expressions;
using Core.Domain.Abstract;
using Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Concrete.EntityFrameworkCore;

public abstract class GenericRepository<TEntity> : GenericRepository<TEntity, int> where TEntity : class, IEntity<int>, new()
{
    public GenericRepository(DbContext context) : base(context) { }
}

public abstract class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
{
    private readonly DbSet<TEntity> _set;

    public GenericRepository(DbContext context)
    {
        var ctx = context ?? throw new ArgumentNullException(nameof(DbContext));
        _set = ctx.Set<TEntity>();
    }

    public TEntity? Get(TKey id)
    {
        return _set.Find(id);
    }

    public async Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken)
    {
        return await _set.FindAsync(id, cancellationToken);
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        return _set.AsNoTracking().FirstOrDefault(predicate);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _set.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public List<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
    {
        return _set.AsNoTracking().Where(predicate).ToList();
    }

    public async Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _set.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }

    public void Add(TEntity entity)
    {
        _set.Add(entity);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _set.AddAsync(entity, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        _set.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _set.Remove(entity);
    }

    public int Count(Expression<Func<TEntity, bool>> predicate)
    {
        return _set.Count(predicate);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _set.CountAsync(predicate, cancellationToken);
    }
}