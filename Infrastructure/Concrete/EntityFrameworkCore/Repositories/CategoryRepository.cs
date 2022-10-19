using Domain.Entities;
using Infrastructure.Abstract;
using Infrastructure.Concrete.EntityFrameworkCore.Contexts;

namespace Infrastructure.Concrete.EntityFrameworkCore.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DataContext context) : base(context) { }
}