namespace Presentation.Extensions;

internal static class ApplicationService
{
    internal static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
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
            app.UseSwaggerUI();
        }

        return app;
    }

    internal static WebApplication AddMiddleware(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }

    internal static async Task RunWebApiAsync(this WebApplication app)
    {
        await app.RunAsync();
    }
}