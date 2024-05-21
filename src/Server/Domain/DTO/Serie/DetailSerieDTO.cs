using Domain.DTO.Image;
using Domain.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Serie
{
    public class DetailSerieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IList<ImageDTO> Images { get; set; }
        public IList<ProductDTO> Products { get; set; }
    }
}
