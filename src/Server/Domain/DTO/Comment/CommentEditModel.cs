namespace Domain.DTO.Comment
{
    public class CommentEditModel
    {
        public string Detail { get; set; }
        public float Rating { get; set; }
        public string ProductSlug { get; set; }
        public string UserId { get; set; }
    }
}
