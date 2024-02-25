using Carter;
using WebApi.Extensions;
using WebApi.Mapsters;
using WebApi.Validations;

var builder = WebApplication.CreateBuilder(args);
{
    builder.ConfigureCors()
        .ConfigureNLog()
        .ConfigureServices()
        .ConfigureMapster()
        .ConfigureSwaggerOpenApi()
        .ConfigureFluentValidation();
}

var app = builder.Build();
{
    app.SetupRequestPipeline();
    app.UseDataSeeder();
    app.MapCarter();
    app.Run();
}
