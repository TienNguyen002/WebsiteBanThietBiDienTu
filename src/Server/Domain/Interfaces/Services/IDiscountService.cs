using Domain.DTO.Discount;

namespace Domain.Interfaces.Services
{
    public interface IDiscountService
    {
        Task<IList<DiscountDTO>> GetAllDiscounts();
        Task<DiscountDTO> GetDiscountById(int id);
        Task<bool> AddDiscount(DiscountEditModel model);
        Task<bool> DeleteDiscount(int id);
    }
}
