using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        //Task<bool> DeleteDiscount(int id);
    }
}
