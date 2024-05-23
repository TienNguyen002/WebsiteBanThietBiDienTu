using Microsoft.AspNetCore.Http;

namespace Domain.DTO.Branch
{
    public class BranchEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
    }
}
