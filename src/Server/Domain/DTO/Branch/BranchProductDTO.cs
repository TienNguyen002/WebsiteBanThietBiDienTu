namespace Domain.DTO.Branch
{
    public class BranchProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
