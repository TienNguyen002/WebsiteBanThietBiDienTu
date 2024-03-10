using Carter;
using Core.Collections;
using Core.DTO.Order;
using Core.Entities;
using Mapster;
using MapsterMapper;
using Services.Apps.Orders;
using System.Net;
using WebApi.Models;
using WebApi.Models.Order;

namespace WebApi.Endpoints
{
    public class OrderEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/orders");

            routeGroupBuilder.MapGet("/", GetOrders)
                .WithName("GetOrders")
                .Produces<ApiResponse<PaginationResult<OrderDto>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetOrderById)
                  .WithName("GetOrderById")
                  .Produces<ApiResponse<OrderDto>>();

            routeGroupBuilder.MapPost("/", AddOrder)
                .WithName("AddOrder")
                .Accepts<OrderEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<OrderDto>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteOrder)
                .WithName("DeleteOrder")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetOrders(
            [AsParameters] OrderFilterModel model,
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            var query = mapper.Map<OrderQuery>(model);
            var orders = await orderRepository.GetPagedOrderAsync<OrderDto>(query, model,
                orders => orders.ProjectToType<OrderDto>());
            var paginationResult = new PaginationResult<OrderDto>(orders);
            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetOrderById(int id,
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            var order = await orderRepository.GetOrderByIdAsync(id);
            return order == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy đơn hàng có id {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<OrderDto>(order)));
        }

        private static async Task<IResult> AddOrder(
            HttpContext context,
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            var model = await OrderEditModel.BindAsync(context);
            var order = model.Id > 0 ? await orderRepository.GetOrderByIdAsync(model.Id) : null;
            if (order == null)
            {
                order = new Order()
                {

                };
            }
            order.CustomerName = model.CustomerName;
            order.Email = model.Email;
            order.Phone = model.Phone;
            order.Address = model.Address;
            order.CartId = model.CartId;
            await orderRepository.AddOrderAsync(order);

            return Results.Ok(ApiResponse.Success(
               mapper.Map<OrderDto>(order), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteOrder(
            int id,
            IOrderRepository orderRepository)
        {
            return await orderRepository.DeleteOrder(id)
              ? Results.Ok(ApiResponse.Success("Xóa đơn hàng thành công", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy đơn hàng có id = {id}"));
        }
    }
}
