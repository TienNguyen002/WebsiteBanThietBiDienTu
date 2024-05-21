using Domain.DTO.Order;
using Domain.DTO.OrderItem;

namespace Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IList<OrderDTO>> GetAllOrders();
        Task<bool> AddOrder(OrderEditModel model);
        Task<IList<OrderItemsDTO>> GetOrderItemsByOrderIdAsync(int id);
        Task<bool> MoveToNextStep(int id);
        Task<bool> CancelOrder(int id);
    }
}
