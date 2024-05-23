using Api.Extensions;
using Api.Mapsters;
using Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    builder.ConfigureCors()
        .ConfigureServices()
        .ConfigureMapster()
        .ConfigureSwaggerOpenApi()
        .ConfigureLogging()
        .ConfigureIdentityJWT();
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseAuthentication();
    app.SetupRequestPipeline();
    app.UseDataSeeder();
    app.MapControllers();
    app.Run();
}
