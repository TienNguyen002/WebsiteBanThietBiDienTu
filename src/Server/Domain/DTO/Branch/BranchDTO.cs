namespace Domain.DTO.Branch
{
    public class BranchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int ProductCount { get; set; }
        //public IList<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
