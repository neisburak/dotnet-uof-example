using Domain.Abstract;

namespace Domain.Entities;

public class ProductFeature : IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Key { get; set; } = default!;
    public string Value { get; set; } = default!;

    public virtual Product Product { get; set; } = default!;
}