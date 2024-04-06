using Domain.DTO.Product;

namespace Domain.DTO.Image
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public ProductDTO Product { get; set; }
    }
}
