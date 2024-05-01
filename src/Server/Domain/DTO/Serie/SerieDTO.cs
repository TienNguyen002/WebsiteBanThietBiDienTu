using Domain.DTO.Comment;
using Domain.DTO.Image;
using Domain.DTO.Product;

namespace Domain.DTO.Serie
{
    public class SerieDTO
    {
        public string Description { get; set; } = null!;
        public IList<CommentDTO> Comments { get; set; }
        public IList<ImageDTO> Images { get; set; }
        public IList<SerieProductDTO> Products { get; set; }
    }
}
