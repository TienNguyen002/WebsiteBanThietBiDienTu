namespace Domain.DTO.Product
{
    public class FilterQuery
    {
        public bool IsSale { get; set; }
        public bool IsHighRating { get; set; }
        public bool IsNew { get; set; }
        public bool IsTop { get; set; }
        public string? Category { get; set; }
        public string? Branch { get; set; }
    }
}
