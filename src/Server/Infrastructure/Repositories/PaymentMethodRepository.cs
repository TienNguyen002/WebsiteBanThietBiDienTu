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
        /// Add Payment Method If Model Has No Id / Update PaymentMethod If Model Has Id
        /// </summary>
        /// <param name="paymentMethod"> Model to add/update </param>
        /// <returns> Added/Updated Payment Method </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddPaymentMethod(PaymentMethod paymentMethod)
        {
            try
            {
                if (paymentMethod.Id > 0)
                {
                    _context.Update(paymentMethod);
                }
                else
                {
                    _context.Add(paymentMethod);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

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
