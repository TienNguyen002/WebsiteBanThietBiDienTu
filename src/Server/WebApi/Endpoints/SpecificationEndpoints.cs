using Carter;
using Core.Collections;
using Core.Entities;
using MapsterMapper;
using Services.Apps.Specifications;
using Services.Apps.Comments;
using Services.Apps.Specifications;
using System.Net;
using WebApi.Models;
using WebApi.Models.Specification;

namespace WebApi.Endpoints
{
    public class SpecificationEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/specifications");

            routeGroupBuilder.MapGet("/", GetAllSpecifications)
                .WithName("GetAllSpecifications")
                .Produces<ApiResponse<PaginationResult<Comment>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetSpecificationById)
                  .WithName("GetSpecificationById")
                  .Produces<ApiResponse<SpecificationDto>>();

            routeGroupBuilder.MapPost("/", AddOrUpdateSpecification)
                .WithName("AddOrUpdateSpecification")
                .Accepts<SpecificationEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<SpecificationDto>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteSpecification)
                .WithName("DeleteSpecification")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetAllSpecifications(
            ISpecificationRepository specificationRepository)
        {
            var comments = await specificationRepository.GetAllSpecificationsAsync();
            return Results.Ok(ApiResponse.Success(comments));
        }

        private static async Task<IResult> GetSpecificationById(int id,
            ISpecificationRepository specificationRepository,
            IMapper mapper)
        {
            var specification = await specificationRepository.GetSpecificationByIdAsync(id);
            return specification == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy thông số có id {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<SpecificationDto>(specification)));
        }

        private static async Task<IResult> AddOrUpdateSpecification(
            HttpContext context,
            ISpecificationRepository specificationRepository,
            IMapper mapper)
        {
            var model = await SpecificationEditModel.BindAsync(context);
            var specification = model.Id > 0 ? await specificationRepository.GetSpecificationByIdAsync(model.Id) : null;
            if (specification == null)
            {
                specification = new Specification()
                {

                };
            }
            specification.SpecificationCategoryId = model.SpeCategoryId;
            specification.Details = model.Details;
            await specificationRepository.AddOrUpdateSpecificationAsync(specification);

            return Results.Ok(ApiResponse.Success(
               mapper.Map<SpecificationDto>(specification), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteSpecification(
            int id,
            ISpecificationRepository specificationRepository)
        {
            return await specificationRepository.DeleteSpecificationAsync(id)
              ? Results.Ok(ApiResponse.Success("Xóa thông số thành công", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy thông số có id = {id}"));
        }
    }
}
