using Domain.Entities;
using Infrastructure.Abstract;

namespace Infrastructure.Concrete.EntityFrameworkCore.Repositories;

public class ProductFeatureRepository : Repository<ProductFeature>, IProductFeatureRepository
{

}