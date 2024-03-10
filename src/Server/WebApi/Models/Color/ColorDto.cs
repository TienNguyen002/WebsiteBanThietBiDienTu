using WebApi.Models.Product;

namespace WebApi.Models.Color
{
    public class ColorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public IList<ProductDto> Products { get; set; }
    }
}
