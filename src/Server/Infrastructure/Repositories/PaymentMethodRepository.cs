using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PaymentMethodRepository : GenericRepository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Delete Payment Method By Id
        /// </summary>
        /// <param name="id"> Id Of PaymentMethod want to delete </param>
        /// <returns> Deleted Payment Method </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeletePaymentMethod(int id)
        {
            var paymentMethodToDelete = await _context.Set<PaymentMethod>()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(paymentMethodToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
