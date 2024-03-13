using Carter;
using Core.Collections;
using Core.DTO.Product;
using Mapster;
using MapsterMapper;
using Services.Apps.Products;
using System.Net;
using WebApi.Models;
using WebApi.Models.Product;

namespace WebApi.Endpoints
{
    public class ProductEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/products");

            routeGroupBuilder.MapGet("/", GetProducts)
                .WithName("GetProducts")
                .Produces<ApiResponse<PaginationResult<ProductDto>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetProductById)
                  .WithName("GetProductById")
                  .Produces<ApiResponse<ProductDto>>();

            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetProductBySlug)
                  .WithName("GetProductBySlug")
                  .Produces<ApiResponse<ProductDto>>();

            routeGroupBuilder.MapGet("/bytag/{tag:regex(^[a-z0-9_-]+$)}", GetProductByTag)
                  .WithName("GetProductByTag")
                  .Produces<ApiResponse<ProductDto>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteProduct)
                .WithName("DeleteProduct")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetProducts(
            [AsParameters] ProductFilterModel model,
            IProductRepository productRepository,
            IMapper mapper)
        {
            var query = mapper.Map<ProductQuery>(model);
            var products = await productRepository.GetPagedProductAsync<ProductDto>(query, model,
                products => products.ProjectToType<ProductDto>());
            var paginationResult = new PaginationResult<ProductDto>(products);
            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetProductById(int id,
            IProductRepository productRepository,
            IMapper mapper)
        {
            var product = await productRepository.GetProductByIdAsync(id);
            return product == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy sản phẩm có id {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<ProductDto>(product)));
        }

        private static async Task<IResult> GetProductBySlug(string slug,
            IProductRepository productRepository,
            IMapper mapper)
        {
            var product = await productRepository.GetProductBySlugAsync(slug);
            return product == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy sản phẩm có slug {slug}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<ProductDto>(product)));
        }

        private static async Task<IResult> GetProductByTag(string tag,
            IProductRepository productRepository,
            IMapper mapper)
        {
            var products = await productRepository.GetProductsByTagAsync(tag);
            return Results.Ok(ApiResponse.Success(products));
        }

        private static async Task<IResult> DeleteProduct(
            int id,
            IProductRepository productRepository)
        {
            return await productRepository.DeleteProduct(id)
              ? Results.Ok(ApiResponse.Success("Xóa sản phẩm thành công", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy sản phẩm có id = {id}"));
        }
    }
}
