using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IList<Order>> GetAllOrders();
    }
}
