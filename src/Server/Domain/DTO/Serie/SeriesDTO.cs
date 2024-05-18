using Domain.DTO.Image;

namespace Domain.DTO.Serie
{
    public class SeriesDTO
    {
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IList<ImageDTO> Images { get; set; }
        public string Category { get; set; } = null!;
        public string Branch { get; set; } = null!;
    }
}
