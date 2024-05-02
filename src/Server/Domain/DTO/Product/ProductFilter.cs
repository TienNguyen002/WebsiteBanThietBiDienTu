using Domain.DTO.Branch;
using Domain.DTO.Category;
using Domain.DTO.Color;

namespace Domain.DTO.Product
{
    public class ProductFilter
    {
        public List<BranchDTO> Branches { get; set; } = new List<BranchDTO>();
        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
        public List<ColorDTO> Colors { get; set; } = new List<ColorDTO>();
    }
}
