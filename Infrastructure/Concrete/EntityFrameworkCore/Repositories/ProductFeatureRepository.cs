using Domain.Entities;
using Infrastructure.Abstract;
using Infrastructure.Concrete.EntityFrameworkCore.Contexts;

namespace Infrastructure.Concrete.EntityFrameworkCore.Repositories;

public class ProductFeatureRepository : GenericRepository<ProductFeature>, IProductFeatureRepository
{
    private readonly DataContext _context;

    public ProductFeatureRepository(DataContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(DataContext));
    }
}