using Microsoft.AspNetCore.Http;

namespace Domain.DTO.Product
{
    public class ProductEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int OrPrice { get; set; }
        public int BranchId { get; set; }
        public int CategoryId { get; set; }
        public string TagSlug { get; set; }
    }
}
