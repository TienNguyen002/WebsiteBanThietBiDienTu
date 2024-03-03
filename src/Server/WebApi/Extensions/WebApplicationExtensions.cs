using Carter;
using Data.Contexts;
using Data.Seeders;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Services.Apps.Categories;
using Services.Apps.Comments;
using Services.Media;
using Services.Timing;

namespace WebApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddCarter();
            builder.Services.AddMemoryCache();

            builder.Services.AddDbContext<WebDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                        .GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ITimeProvider, LocalTimeProvider>();
            builder.Services.AddScoped<IMediaManager, LocalFileSystemMediaManager>();
            builder.Services.AddScoped<IDataSeeder, DataSeeder>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();

            return builder;
        }

        public static WebApplicationBuilder ConfigureCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DeviceWeb", policyBuilder =>
                    policyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
            return builder;
        }

        //Cấu hình việc sử dụng NLog
        public static WebApplicationBuilder ConfigureNLog(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
            return builder;
        }

        public static WebApplicationBuilder ConfigureSwaggerOpenApi(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }

        public static WebApplication SetupRequestPipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseCors("DeviceWeb");

            return app;
        }

        public static IApplicationBuilder UseDataSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            try
            {
                scope.ServiceProvider
                  .GetRequiredService<IDataSeeder>()
                  .Initialize();
            }
            catch (Exception ex)
            {
                scope.ServiceProvider
                    .GetRequiredService<ILogger<Program>>()
                    .LogError(ex, "Could not insert data into database");
            }
            return app;
        }
    }
}
