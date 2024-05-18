using Domain.DTO.Order;

namespace Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IList<OrderDTO>> GetAllOrders();
    }
}
