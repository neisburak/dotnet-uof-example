using Infrastructure;
using Infrastructure.Concrete.EntityFrameworkCore;
using Infrastructure.Concrete.EntityFrameworkCore.Contexts;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection, Action<ServiceOptions> serviceOptions)
    {
        var opt = new ServiceOptions();
        serviceOptions(opt);

        serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(opt.ConnectionString));

        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        return serviceCollection;
    }
}