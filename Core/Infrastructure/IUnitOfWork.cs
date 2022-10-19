namespace Core.Infrastructure;

public interface IUnitOfWork
{
    void SaveChanges();
    Task SaveChangesAsync();
}