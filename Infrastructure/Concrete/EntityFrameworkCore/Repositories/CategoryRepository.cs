using Domain.Entities;
using Infrastructure.Abstract;
using Infrastructure.Concrete.EntityFrameworkCore.Contexts;

namespace Infrastructure.Concrete.EntityFrameworkCore.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(DataContext));
    }
}