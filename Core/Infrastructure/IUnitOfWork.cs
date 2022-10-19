namespace Core.Infrastructure;

public interface IUnitOfWork
{
    int SaveChanges();
    Task<int> SaveChangesAsync();
}