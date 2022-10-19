using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Concrete.EntityFrameworkCore.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductFeature> ProductFeatures => Set<ProductFeature>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(18, 2);

        modelBuilder.Entity<Category>().HasMany(p => p.Children).WithOne(p => p.Parent).HasForeignKey(p => p.ParentId);
        modelBuilder.Entity<Product>().HasMany(p => p.Features).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);

        base.OnModelCreating(modelBuilder);
    }
}