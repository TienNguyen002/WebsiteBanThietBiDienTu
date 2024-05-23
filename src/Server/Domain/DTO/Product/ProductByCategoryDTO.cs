using Domain.DTO.Color;

namespace Domain.DTO.Product
{
    public class ProductByCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public IList<ProductColorDTO> Colors { get; set; } = new List<ProductColorDTO>();
        public int SalePrice { get; set; }
        public int Price { get; set; }
        public int OrPrice { get; set; }
        public float Rating { get; set; }
    }
}
