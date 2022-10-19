namespace Core.Domain.Abstract;

public interface IEntity : IEntity<int> { }

public interface IEntity<TKey> { }