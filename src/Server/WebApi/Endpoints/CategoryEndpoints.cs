using Carter;
using Core.Collections;
using Core.DTO.Category;
using MapsterMapper;
using Services.Apps.Categories;
using System.Net;
using WebApi.Models;
using WebApi.Models.Category;
using Core.Entities;
using SlugGenerator;

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

            routeGroupBuilder.MapGet("/{id:int}", GetCategoryById)
                  .WithName("GetCategoryById")
                  .Produces<ApiResponse<CategoryDto>>();

            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetCategoryBySlug)
                  .WithName("GetCategoryBySlug")
                  .Produces<ApiResponse<CategoryDto>>();

            routeGroupBuilder.MapPost("/", AddOrUpdateCategory)
                .WithName("AddOrUpdateCategory")
                .Accepts<CategoryEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<CategoryItems>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteCategory)
                .WithName("DeleteCategory")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetAllCategories(ICategoryRepository categoryRepository)
        {
            var category = await categoryRepository.GetAllCategoryAsync();
            return Results.Ok(ApiResponse.Success(category));
        }

        private static async Task<IResult> GetCategoryById(int id,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(id, true);
            return category == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy danh mục có id {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<CategoryDto>(category)));
        }

        private static async Task<IResult> GetCategoryBySlug(string slug,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            var category = await categoryRepository.GetCategoryBySlugAsync(slug, true);
            return category == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy danh mục có slug {slug}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<CategoryDto>(category)));
        }

        private static async Task<IResult> AddOrUpdateCategory(
            HttpContext context,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            var model = await CategoryEditModel.BindAsync(context);
            var slug = model.Name.GenerateSlug();
            if (await categoryRepository.IsCategoryExistBySlugAsync(model.Id, slug))
            {
                return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug '{slug}' đã tồn tại"));
            }
            var category = model.Id > 0 ? await categoryRepository.GetCategoryByIdAsync(model.Id) : null;
            if (category == null)
            {
                category = new Category()
                {

                };
            }
            category.Name = model.Name;
            category.UrlSlug = model.Name.GenerateSlug();
            await categoryRepository.AddOrUpdateCategoryAsync(category);

            return Results.Ok(ApiResponse.Success(
                mapper.Map<CategoryItems>(category), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteCategory(
            int id,
            ICategoryRepository categoryRepository)
        {
            return await categoryRepository.DeleteCategoryByIdAsync(id)
              ? Results.Ok(ApiResponse.Success("Xóa danh mục thành công", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy danh mục có id = {id}"));
        }
    }
}
