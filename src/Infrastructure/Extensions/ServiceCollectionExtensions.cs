using Application.Common.Interfaces.Common;
using Infrastructure.Contexts;
using Infrastructure.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DotnetstoreIntranetContext>(q =>
        {
            q.UseSqlite("Data source = DotnetstoreIntranet.db");
            q.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        
        serviceCollection
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddScoped<IUnitOfWork, UnitOfWork>();

        return serviceCollection;
    }
}