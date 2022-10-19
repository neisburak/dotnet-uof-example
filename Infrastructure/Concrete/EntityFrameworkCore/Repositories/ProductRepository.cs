using Domain.Entities;
using Infrastructure.Abstract;

namespace Infrastructure.Concrete.EntityFrameworkCore.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{

}