using WebApi.Models.Category;
using WebApi.Models.Product;

namespace WebApi.Models.Trademark
{
    public class TrademarkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public IList<CategoryForTrademarkDto> Categories { get; set; }
        public IList<ProductDto> Products { get; set; }
    }
}
