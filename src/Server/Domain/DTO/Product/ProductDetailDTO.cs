using Domain.DTO.Color;
using Domain.DTO.Serie;

namespace Domain.DTO.Product
{
    public class ProductDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string Specification { get; set; } = null!;
        public int Amount { get; set; }
        public int SalePrice { get; set; }
        public int Price { get; set; }
        public int OrPrice { get; set; }
        public IList<ProductColorDTO> Colors { get; set; }
        public SerieDTO Serie { get; set; }
    }
}
