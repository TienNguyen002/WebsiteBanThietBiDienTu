using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        Task<bool> AddDiscount(Discount discount);
        Task<bool> DeleteDiscount(int id);
    }
}
