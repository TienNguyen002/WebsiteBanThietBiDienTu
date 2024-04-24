using Domain.DTO.Product;

namespace Domain.DTO.Sale
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
        public IList<SaleProductDTO> Products { get; set; } = new List<SaleProductDTO>();
    }
}
