using Carter;
using Core.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Routing;
using Services.Apps.Images;
using Services.Media;
using System.Net;
using WebApi.Models;
using WebApi.Models.Image;

namespace WebApi.Endpoints
{
    public class ImageEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/images");

            routeGroupBuilder.MapGet("/{id:int}", GetImageById)
                  .WithName("GetImageById")
                  .Produces<ApiResponse<ImageDto>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteImage)
                .WithName("DeleteImage")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetImageById(int id,
            IImageRepository imageRepository,
            IMapper mapper)
        {
            var image = await imageRepository.GetImageByIdAsync(id);
            return image == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy ảnh có id {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<ImageDto>(image)));
        }

        private static async Task<IResult> DeleteImage(
            int id,
            IImageRepository imageRepository)
        {
            return await imageRepository.DeleteImage(id)
              ? Results.Ok(ApiResponse.Success("Xóa ảnh thành công", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy ảnh có id = {id}"));
        }
    }
}
