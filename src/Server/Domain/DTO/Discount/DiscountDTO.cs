using Domain.DTO.Product;

namespace Domain.DTO.Discount
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
        public ProductDTO? Product { get; set; } 
    }
}
