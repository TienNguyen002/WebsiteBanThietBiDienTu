using Carter;
using Core.Collections;
using Core.DTO.Role;
using Core.DTO.Status;
using Core.Entities;
using Services.Apps.Roles;
using Services.Apps.Statuses;
using WebApi.Models;

namespace WebApi.Endpoints
{
    public class OtherEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/others");

            routeGroupBuilder.MapGet("/status", GetAllStatus)
                .WithName("GetAllStatus")
                .Produces<ApiResponse<PaginationResult<StatusItems>>>();

            routeGroupBuilder.MapGet("/roles", GetAllRoles)
                .WithName("GetAllRoles")
                .Produces<ApiResponse<PaginationResult<RoleItems>>>();
        }

        private static async Task<IResult> GetAllStatus(IStatusRepository statusRepository)
        {
            var statuses = await statusRepository.GetAllStatusAsync();
            return Results.Ok(ApiResponse.Success(statuses));
        }

        private static async Task<IResult> GetAllRoles(IRoleRepository roleRepository)
        {
            var roles = await roleRepository.GetAllRolesAsync();
            return Results.Ok(ApiResponse.Success(roles));
        }
    }
}
