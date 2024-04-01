using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IPaymentMethodRepository : IGenericRepository<PaymentMethod>
    {
        Task<bool> AddPaymentMethod(PaymentMethod paymentMethod);
        Task<bool> DeletePaymentMethod(int id);
    }
}
