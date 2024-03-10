using Carter;
using Core.Collections;
using Core.DTO.User;
using Core.Entities;
using MapsterMapper;
using Services.Apps.Customers;
using System.Net;
using WebApi.Models;
using WebApi.Models.Customer;

namespace WebApi.Endpoints
{
    public class UserEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/users");

            routeGroupBuilder.MapGet("/all", GetAllUsers)
                .WithName("GetAllUsers")
                .Produces<ApiResponse<PaginationResult<UserItems>>>();

            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetUserBySlug)
                  .WithName("GetCustomerBySlug")
                  .Produces<ApiResponse<UserDto>>();
        }

        private static async Task<IResult> GetAllUsers(IUserRepository customerRepository)
        {
            var customer = await customerRepository.GetUsersAsync();
            return Results.Ok(ApiResponse.Success(customer));
        }

        private static async Task<IResult> GetUserBySlug(string slug,
            IUserRepository customerRepository,
            IMapper mapper)
        {
            var customer = await customerRepository.GetUserBySlugAsync(slug);
            return customer == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy khách hàng có slug {slug}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<UserDto>(customer)));
        }
    }
}
