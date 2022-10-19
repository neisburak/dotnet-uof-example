using Domain.Entities;
using Infrastructure.Abstract;
using Infrastructure.Concrete.EntityFrameworkCore.Contexts;

namespace Infrastructure.Concrete.EntityFrameworkCore.Repositories;

public class ProductFeatureRepository : GenericRepository<ProductFeature>, IProductFeatureRepository
{
    public ProductFeatureRepository(DataContext context) : base(context) { }
}