namespace Domain.DTO.Product
{
    public class SerieProductDTO
    {
        public string ShortName { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public int Price { get; set; }
    }
}
