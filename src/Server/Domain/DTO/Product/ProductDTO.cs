namespace Domain.DTO.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string Description { get; set; } = null!;
        public string Specification { get; set; } = null!;
        public int Amount { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
        public decimal OrPrice { get; set; }
    }
}
