namespace Domain.DTO.Product
{
    public class ProductQuery
    {
        public bool IsSale { get; set; }
        public bool IsHighRating { get; set; }
        public bool IsNew { get; set; }
        public bool IsTop { get; set; }
        public string? Keyword { get; set; }
        public string? SortOrder { get; set; }
        public string? Category { get; set; }
        public string? Branch { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string? Serie { get; set; }
        public float Rating { get; set; }
        public string? Color { get; set; }
    }
}
