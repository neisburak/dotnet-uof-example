using Domain.Entities;
using Infrastructure.Abstract;
using Infrastructure.Concrete.EntityFrameworkCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Concrete.EntityFrameworkCore.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(DataContext context) : base(context) { }

    public async Task<List<Product>> GetMostExpensiveProductsAsync(int count, CancellationToken cancellationToken)
    {
        return await Context.Products.OrderByDescending(o => o.UnitPrice).Take(count).ToListAsync(cancellationToken);
    }

    public async Task<List<Product>> GetProductsAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        return await Context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
    }

    private DataContext Context { get { return (_context as DataContext)!; } }
}