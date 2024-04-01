using Domain.DTO.Product;

namespace Domain.DTO.Color
{
    public class ColorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public IList<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
