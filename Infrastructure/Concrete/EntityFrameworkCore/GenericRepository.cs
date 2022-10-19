using System.Linq.Expressions;
using Domain.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Concrete.EntityFrameworkCore;

public abstract class GenericRepository<TEntity> : GenericRepository<TEntity, int> where TEntity : class, IEntity<int>, new()
{
    public GenericRepository(DbContext context) : base(context) { }
}

public abstract class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
{
    protected readonly DbContext _context;

    public GenericRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(DbContext));
    }

    public virtual TEntity? Get(TKey id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public virtual async Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().FindAsync(new object[] { id! }, cancellationToken);
    }

    public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().AsNoTracking().FirstOrDefault(predicate);
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual List<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
    }

    public virtual async Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }

    public virtual void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public virtual void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public virtual int Count(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().Count(predicate);
    }

    public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().CountAsync(predicate, cancellationToken);
    }
}