using Carter;
using Core.Collections;
using Core.Entities;
using MapsterMapper;
using Services.Apps.Carts;
using System.Net;
using WebApi.Models;
using WebApi.Models.Cart;

namespace WebApi.Endpoints
{
    public class CartEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/carts");

            routeGroupBuilder.MapGet("/", GetCartByUserSlug)
                .WithName("GetCartByUserSlug")
                .Produces<ApiResponse<CartDto>>();

            routeGroupBuilder.MapPost("/", AddProductToCart)
                .WithName("AddProductToCart")
                .Produces<ApiResponse<CartDto>>();

            routeGroupBuilder.MapDelete("/", RemoveProductFromCart)
                .WithName("RemoveProductFromCart")
                .Produces<ApiResponse<CartDto>>();

            routeGroupBuilder.MapPost("/remove", RemoveCart)
                .WithName("RemoveCart")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetCartByUserSlug(string userSlug, ICartRepository cartRepository, IMapper mapper)
        {
            var cart = await cartRepository.GetCartByUserSlugAsync(userSlug);
            return cart == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy"))
                : Results.Ok(ApiResponse.Success(mapper.Map<CartDto>(cart)));
        }

        private static async Task<IResult> AddProductToCart(string userSlug, string productSlug, ICartRepository cartRepository, IMapper mapper)
        {
            var cart = await cartRepository.AddProductToCartAsync(userSlug, productSlug);
            return Results.Ok(ApiResponse.Success(mapper.Map<CartDto>(cart)));
        }

        private static async Task<IResult> RemoveProductFromCart(string userSlug, string productSlug, ICartRepository cartRepository, IMapper mapper)
        {
            var cart = await cartRepository.RemoveProductFromCartAsync(userSlug, productSlug);
            return Results.Ok(ApiResponse.Success(mapper.Map<CartDto>(cart)));
        }

        private static async Task<IResult> RemoveCart(string userSlug, ICartRepository cartRepository)
        {
            return await cartRepository.RemoveCartAsync(userSlug)
                ? Results.Ok(ApiResponse.Success("DONE"))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy giỏ hàng"));
        }
    }
}
