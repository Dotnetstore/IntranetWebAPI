using Application;
using Domain;
using Infrastructure;

namespace Presentation.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddWebApi(this IServiceCollection serviceCollection)
    {
        AddMediator(serviceCollection);
        return serviceCollection;
    }

    private static void AddMediator(IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(q => q.RegisterServicesFromAssemblies(
            typeof(IDomainAssemblyMarker).Assembly, 
            typeof(IApplicationAssemblyMarker).Assembly, 
            typeof(IInfrastructureAssemblyMarker).Assembly));
    }
}