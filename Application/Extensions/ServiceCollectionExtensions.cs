using Application.Abstract;
using Application.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoryService, CategoryManager>();
        serviceCollection.AddScoped<IProductService, ProductManager>();

        return serviceCollection;
    }
}