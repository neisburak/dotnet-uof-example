using Domain.Entities;
using Infrastructure.Abstract;

namespace Infrastructure.Concrete.EntityFrameworkCore.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{

}