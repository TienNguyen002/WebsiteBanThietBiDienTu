using Application.Media;
using Infrastructure.Contexts;
using Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddMemoryCache();

            builder.Services.AddDbContext<DeviceWebDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                        .GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IMediaManager, LocalFileSystemMediaManager>();
            builder.Services.AddScoped<IDataSeeder, DataSeeder>();
            //builder.Services.AddScoped<ICartRepository, CartRepository>();
            //builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            //builder.Services.AddScoped<IColorRepository, ColorRepository>();
            //builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            //builder.Services.AddScoped<IImageRepository, ImageRepository>();
            //builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            //builder.Services.AddScoped<IProductRepository, ProductRepository>();
            //builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            //builder.Services.AddScoped<ISpecificationRepository, SpecificationRepository>();
            //builder.Services.AddScoped<ISpecificationCategoryRepository, SpecificationCategoryRepository>();
            //builder.Services.AddScoped<IStatusRepository, StatusRepository>();
            //builder.Services.AddScoped<ITagRepository, TagRepository>();
            //builder.Services.AddScoped<ITrademarkRepository, TrademarkRepository>();
            //builder.Services.AddScoped<IUserRepository, UserRepository>();

            return builder;
        }

        public static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder builder)
        {
            var _logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.AddSerilog(_logger);
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
        //public static WebApplicationBuilder ConfigureNLog(this WebApplicationBuilder builder)
        //{
        //    builder.Logging.ClearProviders();
        //    builder.Host.UseNLog();
        //    return builder;
        //}

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
