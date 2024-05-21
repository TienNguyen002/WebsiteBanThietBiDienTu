using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IList<Order>> GetAllOrders();
        Task<int> CountOrders();
        Task<IList<OrderItem>> GetOrderItemsByOrderIdAsync(int id);
    }
}
