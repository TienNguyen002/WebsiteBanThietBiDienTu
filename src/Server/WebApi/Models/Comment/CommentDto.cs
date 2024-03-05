namespace WebApi.Models.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ProductUrlSlug { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
