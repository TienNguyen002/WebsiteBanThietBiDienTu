using Microsoft.AspNetCore.Http;

namespace Domain.DTO.Image
{
    public class ImageEditModel
    {
        public int Id { get; set; }
        public IFormFile ImageFile { get; set; }
        public int ProductId { get; set; }
    }
}
