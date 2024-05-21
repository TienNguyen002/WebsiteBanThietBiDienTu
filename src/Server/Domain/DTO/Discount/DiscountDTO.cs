using Domain.DTO.Product;

namespace Domain.DTO.Discount
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public double DiscountPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProductDTO? Product { get; set; } 
    }
}
