using Carter;
using Core.Collections;
using Core.DTO.Color;
using Core.Entities;
using Mapster;
using MapsterMapper;
using Services.Apps.Colors;
using SlugGenerator;
using System.Net;
using WebApi.Models;
using WebApi.Models.Color;

namespace WebApi.Endpoints
{
    public class ColorEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/colors");

            routeGroupBuilder.MapGet("/", GetColors)
                .WithName("GetColors")
                .Produces<ApiResponse<PaginationResult<ColorDto>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetColorById)
                  .WithName("GetColorById")
                  .Produces<ApiResponse<ColorDto>>();

            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetColorBySlug)
                  .WithName("GetColorBySlug")
                  .Produces<ApiResponse<ColorDto>>();

            routeGroupBuilder.MapPost("/", AddOrUpdateColor)
                .WithName("AddOrUpdateColor")
                .Accepts<ColorEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<ColorDto>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteColor)
                .WithName("DeleteColor")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetColors(
            [AsParameters] ColorFilterModel model,
            IColorRepository colorRepository,
            IMapper mapper)
        {
            var query = mapper.Map<ColorQuery>(model);
            var colors = await colorRepository.GetPagedColorAsync<ColorDto>(query, model,
                colors => colors.ProjectToType<ColorDto>());
            var paginationResult = new PaginationResult<ColorDto>(colors);
            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetColorById(int id,
            IColorRepository colorRepository,
            IMapper mapper)
        {
            var color = await colorRepository.GetColorByIdAsync(id);
            return color == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy màu có id {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<ColorDto>(color)));
        }

        private static async Task<IResult> GetColorBySlug(string slug,
            IColorRepository colorRepository,
            IMapper mapper)
        {
            var color = await colorRepository.GetColorBySlugAsync(slug);
            return color == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy màu có slug {slug}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<ColorDto>(color)));
        }

        private static async Task<IResult> AddOrUpdateColor(
            HttpContext context,
            IColorRepository colorRepository,
            IMapper mapper)
        {
            var model = await ColorEditModel.BindAsync(context);
            if(await colorRepository.IsColorExistBySlugAsync(model.Id, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug '{model.UrlSlug}' đã tồn tại"));
            }
            var color = model.Id > 0 ? await colorRepository.GetColorByIdAsync(model.Id) : null;
            if(color == null)
            {
                color = new Color()
                {

                };
            }
            color.Name = model.Name;
            color.UrlSlug = model.UrlSlug;
            await colorRepository.AddOrUpdateColorAsync(color);

            return Results.Ok(ApiResponse.Success(
               mapper.Map<ColorDto>(color), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteColor(
            int id,
            IColorRepository colorRepository)
        {
            return await colorRepository.DeleteColor(id)
              ? Results.Ok(ApiResponse.Success("Xóa màu thành công", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy màu có id = {id}"));
        }
    }
}
