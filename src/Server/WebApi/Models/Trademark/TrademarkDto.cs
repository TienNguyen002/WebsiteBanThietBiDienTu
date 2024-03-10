using WebApi.Models.Category;

namespace WebApi.Models.Trademark
{
    public class TrademarkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public IList<CategoryDto> Categories { get; set; }
    }
}
