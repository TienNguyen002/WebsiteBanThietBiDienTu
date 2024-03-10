using WebApi.Models.SpecificationCategory;

namespace WebApi.Models.Specification
{
    public class SpecificationDto
    {
        public int Id { get; set; }
        public SpecificationCategoryDto SpecificationCategory { get; set; }
        public string Details { get; set; }
    }
}
