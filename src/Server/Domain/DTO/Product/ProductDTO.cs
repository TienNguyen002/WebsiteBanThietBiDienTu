using Domain.DTO.Branch;
using Domain.DTO.Color;

namespace Domain.DTO.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public BranchProductDTO Branch { get; set; }
        public IList<ProductColorDTO> Colors { get; set; } = new List<ProductColorDTO>();
        public int SalePrice { get; set; }
        public int Price { get; set; }
        public int OrPrice { get; set; }
        public decimal Rating { get; set; }
    }
}
