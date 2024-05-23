using Microsoft.AspNetCore.Http;

namespace Domain.DTO.Product
{
    public class ProductEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string ShortDescription { get; set; }
        public string Specification { get; set; }
        public int? Price { get; set; }
        public int OrPrice { get; set; }
        public int SerieId { get; set; }
        public IList<string>? Colors { get; set; }
    }
}
