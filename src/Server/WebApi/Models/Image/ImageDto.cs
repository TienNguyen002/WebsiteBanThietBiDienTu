using WebApi.Models.Product;

namespace WebApi.Models.Image
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public ProductDto Product { get; set; }
    }
}
