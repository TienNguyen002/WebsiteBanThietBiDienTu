using Carter;
using Core.Collections;
using Core.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using System.Net;
using WebApi.Models.Tag;
using WebApi.Models;
using Services.Apps.Tags;

namespace WebApi.Endpoints
{
    public class TagEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/tag");

            routeGroupBuilder.MapGet("/", GetAllTag)
                .WithName("GetAllTag")
                .Produces<ApiResponse<PaginationResult<TagDto>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetTagById)
                  .WithName("GetTagById")
                  .Produces<ApiResponse<TagDto>>();

            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetTagBySlug)
                  .WithName("GetTagBySlug")
                  .Produces<ApiResponse<TagDto>>();

            routeGroupBuilder.MapPost("/", AddOrUpdateTag)
                .WithName("AddOrUpdateTag")
                .Accepts<TagEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<TagDto>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteTag)
                .WithName("DeleteTag")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetAllTag(
            ITagRepository tagRepository,
            IMapper mapper)
        {
            var tags = await tagRepository.GetAllTagsAsync();
            return Results.Ok(ApiResponse.Success(tags));
        }

        private static async Task<IResult> GetTagById(int id,
            ITagRepository tagRepository,
            IMapper mapper)
        {
            var tag = await tagRepository.GetTagByIdAsync(id);
            return tag == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy tag có id {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<TagDto>(tag)));
        }

        private static async Task<IResult> GetTagBySlug(string slug,
            ITagRepository tagRepository,
            IMapper mapper)
        {
            var tag = await tagRepository.GetTagBySlugAsync(slug);
            return tag == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy tag có slug {slug}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<TagDto>(tag)));
        }

        private static async Task<IResult> AddOrUpdateTag(
            HttpContext context,
            ITagRepository tagRepository,
            IMapper mapper)
        {
            var model = await TagEditModel.BindAsync(context);
            if (await tagRepository.IsTagExistBySlugAsync(model.Id, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug '{model.UrlSlug}' đã tồn tại"));
            }
            var tag = model.Id > 0 ? await tagRepository.GetTagByIdAsync(model.Id) : null;
            if (tag == null)
            {
                tag = new Tag()
                {

                };
            }
            tag.Name = model.Name;
            tag.UrlSlug = model.UrlSlug;
            await tagRepository.AddOrUpdateTagAsync(tag);

            return Results.Ok(ApiResponse.Success(
               mapper.Map<TagDto>(tag), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteTag(
            int id,
            ITagRepository tagRepository)
        {
            return await tagRepository.DeleteTagAsync(id)
              ? Results.Ok(ApiResponse.Success("Xóa tag thành công", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy tag có id = {id}"));
        }
    }
}
