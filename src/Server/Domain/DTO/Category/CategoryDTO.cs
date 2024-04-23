using Domain.DTO.Product;

namespace Domain.DTO.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public string? ImageUrl { get; set; }
        //public IList<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
