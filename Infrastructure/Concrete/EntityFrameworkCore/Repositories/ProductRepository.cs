using Domain.Entities;
using Infrastructure.Abstract;
using Infrastructure.Concrete.EntityFrameworkCore.Contexts;

namespace Infrastructure.Concrete.EntityFrameworkCore.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(DataContext));
    }
}