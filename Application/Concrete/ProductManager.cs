using Application.Abstract;
using Domain.Entities;
using Infrastructure;

namespace Application.Concrete;

public class ProductManager : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Product?> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Products.GetAsync(id, cancellationToken);
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _unitOfWork.Products.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Product>> GetAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Products.GetProductsAsync(page, pageSize, cancellationToken);
    }

    public async Task<List<Product>> GetMostExpensivesAsync(CancellationToken cancellationToken)
    {
        return await _unitOfWork.Products.GetMostExpensiveProductsAsync(10, cancellationToken);
    }
}