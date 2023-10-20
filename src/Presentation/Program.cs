using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

await builder
    .AddServices()
    .AddWebApiServices()
    .AddSwagger()
    .AddMiddleware()
    .RunWebApiAsync();