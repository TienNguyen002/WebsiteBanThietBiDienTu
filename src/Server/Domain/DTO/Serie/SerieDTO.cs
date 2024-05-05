using Domain.DTO.Branch;
using Domain.DTO.Comment;
using Domain.DTO.Image;
using Domain.DTO.Product;

namespace Domain.DTO.Serie
{
    public class SerieDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; }
        public BranchProductDTO Branch { get; set; }
        public IList<CommentDTO> Comments { get; set; }
        public IList<ImageDTO> Images { get; set; }
        public IList<SerieProductDTO> Products { get; set; }
    }
}
