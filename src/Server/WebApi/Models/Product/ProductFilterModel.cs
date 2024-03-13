namespace WebApi.Models.Product
{
    public class ProductFilterModel : PagingModel
    {
        public string Keyword { get; set; }
        public string CategorySlug { get; set; }
        public string TrademarkSlug { get; set; }
        public string Tag { get; set; }
    }
}
