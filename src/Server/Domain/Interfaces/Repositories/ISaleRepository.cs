using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<Sale> GetCurrentSale(int id);
    }
}
