namespace Domain.DTO.Category
{
    public class CategoryProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
