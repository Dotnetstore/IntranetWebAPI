using Application.Extensions;
using Infrastructure.Extensions;
using Presentation.Middleware;

namespace Presentation.Extensions;

internal static class ApplicationService
{
    internal static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddApplication()
            .AddInfrastructure()
            .AddWebApi();
        return builder;
    }

    internal static WebApplication AddWebApiServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder.Build();
    }

    internal static WebApplication AddSwagger(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                foreach (var description in app.DescribeApiVersions())
                {
                    x.SwaggerEndpoint( $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName);
                }
            });
        }

        return app;
    }

    internal static WebApplication AddMiddleware(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseMiddleware<ValidationMappingMiddleware>();
        app.MapControllers();

        return app;
    }

    internal static async Task RunWebApiAsync(this WebApplication app)
    {
        await app.RunAsync();
    }
}