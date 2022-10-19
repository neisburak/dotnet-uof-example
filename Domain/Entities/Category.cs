using Domain.Abstract;

namespace Domain.Entities;

public class Category : IEntity
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public virtual Category Parent { get; set; } = default!;
    public virtual ICollection<Category> Children { get; set; } = new HashSet<Category>();
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
}