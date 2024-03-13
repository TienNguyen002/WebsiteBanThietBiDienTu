using Carter;
using Core.Collections;
using Core.Entities;
using MapsterMapper;
using Services.Apps.Trademarks;
using System.Net;
using WebApi.Models;
using WebApi.Models.Trademark;

namespace WebApi.Endpoints
{
    public class TrademarkEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/trademarks");

            routeGroupBuilder.MapGet("/", GetAllTrademark)
                .WithName("GetAllTrademark")
                .Produces<ApiResponse<PaginationResult<TrademarkDto>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetTrademarkById)
                  .WithName("GetTrademarkById")
                  .Produces<ApiResponse<TrademarkDto>>();

            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetTrademarkBySlug)
                  .WithName("GetTrademarkBySlug")
                  .Produces<ApiResponse<TrademarkDto>>();

            routeGroupBuilder.MapPost("/", AddOrUpdateTrademark)
                .WithName("AddOrUpdateTrademark")
                .Accepts<TrademarkEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<TrademarkDto>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteTrademark)
                .WithName("DeleteTrademark")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetAllTrademark(
            ITrademarkRepository specificationCategoryRepository)
        {
            var specificationCategories = await specificationCategoryRepository.GetAllTrademarksAsync();
            return Results.Ok(ApiResponse.Success(specificationCategories));
        }

        private static async Task<IResult> GetTrademarkById(int id,
            ITrademarkRepository specificationCategoryRepository,
            IMapper mapper)
        {
            var specificationCategory = await specificationCategoryRepository.GetTrademarkByIdAsync(id);
            return specificationCategory == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy thương hiệu có id {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<TrademarkDto>(specificationCategory)));
        }

        private static async Task<IResult> GetTrademarkBySlug(string slug,
            ITrademarkRepository specificationCategoryRepository,
            IMapper mapper)
        {
            var specificationCategory = await specificationCategoryRepository.GetTrademarkBySlugAsync(slug);
            return specificationCategory == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy thương hiệu có slug {slug}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<TrademarkDto>(specificationCategory)));
        }

        private static async Task<IResult> AddOrUpdateTrademark(
            HttpContext context,
            ITrademarkRepository specificationCategoryRepository,
            IMapper mapper)
        {
            var model = await TrademarkEditModel.BindAsync(context);
            if (await specificationCategoryRepository.IsTrademarkExistBySlugAsync(model.Id, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug '{model.UrlSlug}' đã tồn tại"));
            }
            var specificationCategory = model.Id > 0 ? await specificationCategoryRepository.GetTrademarkByIdAsync(model.Id) : null;
            if (specificationCategory == null)
            {
                specificationCategory = new Trademark()
                {

                };
            }
            specificationCategory.Name = model.Name;
            specificationCategory.UrlSlug = model.UrlSlug;
            await specificationCategoryRepository.AddOrUpdateTrademarkAsync(specificationCategory);

            return Results.Ok(ApiResponse.Success(
               mapper.Map<TrademarkDto>(specificationCategory), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteTrademark(
            int id,
            ITrademarkRepository specificationCategoryRepository)
        {
            return await specificationCategoryRepository.DeleteTrademarkAsync(id)
              ? Results.Ok(ApiResponse.Success("Xóa thương hiệu thành công", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy thương hiệu có id = {id}"));
        }
    }
}
