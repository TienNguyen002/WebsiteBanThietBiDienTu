namespace Domain.DTO.Product
{
    public class SerieProductDTO
    {
        public string ShortName { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public int OrPrice { get; set; }
        public int Price { get; set; }
    }
}
