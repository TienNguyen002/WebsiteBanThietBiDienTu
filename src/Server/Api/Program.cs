using Api.Extensions;
using Api.Mapsters;
using Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    builder.ConfigureCors()
        .ConfigureServices()
        .ConfigureMapster()
        .ConfigureSwaggerOpenApi()
        .ConfigureLogging();
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.SetupRequestPipeline();
    app.UseDataSeeder();
    app.MapControllers();
    app.Run();
}
