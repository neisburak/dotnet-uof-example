using Entities.Abstract;

namespace Entities.Concrete;

public class Product : IEntity
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = default!;
    public string Detail { get; set; } = default!;
    public int UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }

    public virtual Category Category { get; set; } = default!;
    public virtual ICollection<ProductFeature> Features { get; set; } = new HashSet<ProductFeature>();
}