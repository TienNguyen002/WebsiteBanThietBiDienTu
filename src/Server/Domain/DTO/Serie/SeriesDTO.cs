using Domain.DTO.Image;

namespace Domain.DTO.Serie
{
    public class SeriesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public float Rating { get; set; }
        public string Description { get; set; } = null!;
        public IList<ImageDTO> Images { get; set; }
        public string Category { get; set; } = null!;
        public string Branch { get; set; } = null!;
    }
}
