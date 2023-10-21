using Application;
using Asp.Versioning;
using Domain;
using Infrastructure;
using Microsoft.Extensions.Options;
using Presentation.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Presentation.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddWebApi(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddMediator()
            .AddVersioning()
            .AddSwagger();
        
        return serviceCollection;
    }

    private static IServiceCollection AddMediator(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(q => q.RegisterServicesFromAssemblies(
            typeof(IDomainAssemblyMarker).Assembly, 
            typeof(IApplicationAssemblyMarker).Assembly, 
            typeof(IInfrastructureAssemblyMarker).Assembly));

        return serviceCollection;
    }

    private static IServiceCollection AddVersioning(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1.0);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
            x.ApiVersionReader = new MediaTypeApiVersionReader("api-version");
        }).AddMvc().AddApiExplorer();

        return serviceCollection;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
            .AddSwaggerGen(x => x.OperationFilter<SwaggerDefaultValues>());

        return serviceCollection;
    }
}