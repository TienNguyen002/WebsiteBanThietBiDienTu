using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IList<Order>> GetAllOrders();
        Task<int> CountOrders();
        Task<IList<Order>> GetOrdersByUserIdAsync(string userId);

    }
}
