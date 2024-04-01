using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Add Discount If Model Has No Id / Update Discount If Model Has Id
        /// </summary>
        /// <param name="discount"> Model to add/update </param>
        /// <returns> Added/Updated Discount </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddDiscount(Discount discount)
        {
            try
            {
                if (discount.Id > 0)
                {
                    _context.Update(discount);
                }
                else
                {
                    _context.Add(discount);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Discount By Id
        /// </summary>
        /// <param name="id"> Id Of Discount want to delete </param>
        /// <returns> Deleted Discount </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteDiscount(int id)
        {
            var discountToDelete = await _context.Set<Discount>()
                .Include(c => c.Product)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(discountToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
