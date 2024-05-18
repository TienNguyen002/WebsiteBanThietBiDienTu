using Domain.DTO.Sale;

namespace Domain.Interfaces.Services
{
    public interface ISaleService
    {
        Task<SaleDTO> GetSaleById(int id);
        Task<SaleDTO> GetCurrentSale(int id);
        Task<bool> UpdateSale(SaleEditModel model);
    }
}
