using WebApi.Models.Product;

namespace WebApi.Models.Tag
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public IList<ProductDto> Products { get; set; }
    }
}
