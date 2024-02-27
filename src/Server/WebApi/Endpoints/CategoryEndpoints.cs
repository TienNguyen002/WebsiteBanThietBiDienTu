using Carter;
using Core.Collections;
using Core.DTO.Category;
using Services.Apps.Categories;
using WebApi.Models;

namespace WebApi.Endpoints
{
    public class CategoryEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/categories");

            routeGroupBuilder.MapGet("/all", GetAllCategories)
                .WithName("GetAllCategories")
                .Produces<ApiResponse<PaginationResult<CategoryItems>>>();
        }

        private static async Task<IResult> GetAllCategories(ICategoryRepository categoryRepository)
        {
            var category = await categoryRepository.GetAllCategoriesAsync();
            return Results.Ok(ApiResponse.Success(category));
        }
    }
}
