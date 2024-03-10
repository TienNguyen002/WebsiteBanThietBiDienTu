using Carter;
using Core.Collections;
using Core.Entities;
using MapsterMapper;
using Services.Apps.SpecificationCategories;
using System.Net;
using WebApi.Models;
using WebApi.Models.SpecificationCategory;

namespace WebApi.Endpoints
{
    public class SpecificationCategoryEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/specificationCategory");

            routeGroupBuilder.MapGet("/", GetAllSpecificationCategory)
                .WithName("GetAllSpecificationCategory")
                .Produces<ApiResponse<PaginationResult<SpecificationCategory>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetSpecificationCategoryById)
                  .WithName("GetSpecificationCategoryById")
                  .Produces<ApiResponse<SpecificationCategoryDto>>();

            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetSpecificationCategoryBySlug)
                  .WithName("GetSpecificationCategoryBySlug")
                  .Produces<ApiResponse<SpecificationCategoryDto>>();

            routeGroupBuilder.MapPost("/", AddOrUpdateSpecificationCategory)
                .WithName("AddOrUpdateSpecificationCategory")
                .Accepts<SpecificationCategoryEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<SpecificationCategoryDto>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteSpecificationCategory)
                .WithName("DeleteSpecificationCategory")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetAllSpecificationCategory(
            ISpecificationCategoryRepository specificationCategoryRepository)
        {
            var specificationCategories = await specificationCategoryRepository.GetAllSpecificationCategoriesAsync();
            return Results.Ok(ApiResponse.Success(specificationCategories));
        }

        private static async Task<IResult> GetSpecificationCategoryById(int id,
            ISpecificationCategoryRepository specificationCategoryRepository,
            IMapper mapper)
        {
            var specificationCategory = await specificationCategoryRepository.GetSpecificationCategoryByIdAsync(id);
            return specificationCategory == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy danh mục có id {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<SpecificationCategoryDto>(specificationCategory)));
        }

        private static async Task<IResult> GetSpecificationCategoryBySlug(string slug,
            ISpecificationCategoryRepository specificationCategoryRepository,
            IMapper mapper)
        {
            var specificationCategory = await specificationCategoryRepository.GetSpecificationCategoryBySlugAsync(slug);
            return specificationCategory == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy danh mục có slug {slug}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<SpecificationCategoryDto>(specificationCategory)));
        }

        private static async Task<IResult> AddOrUpdateSpecificationCategory(
            HttpContext context,
            ISpecificationCategoryRepository specificationCategoryRepository,
            IMapper mapper)
        {
            var model = await SpecificationCategoryEditModel.BindAsync(context);
            if (await specificationCategoryRepository.IsSpecificationCategoryExistBySlugAsync(model.Id, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug '{model.UrlSlug}' đã tồn tại"));
            }
            var specificationCategory = model.Id > 0 ? await specificationCategoryRepository.GetSpecificationCategoryByIdAsync(model.Id) : null;
            if (specificationCategory == null)
            {
                specificationCategory = new SpecificationCategory()
                {

                };
            }
            specificationCategory.Name = model.Name;
            specificationCategory.UrlSlug = model.UrlSlug;
            await specificationCategoryRepository.AddOrUpdateSpecificationCategoryAsync(specificationCategory);

            return Results.Ok(ApiResponse.Success(
               mapper.Map<SpecificationCategoryDto>(specificationCategory), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteSpecificationCategory(
            int id,
            ISpecificationCategoryRepository specificationCategoryRepository)
        {
            return await specificationCategoryRepository.DeleteSpecificationCategoryAsync(id)
              ? Results.Ok(ApiResponse.Success("Xóa danh mục thành công", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy danh mục có id = {id}"));
        }
    }
}
