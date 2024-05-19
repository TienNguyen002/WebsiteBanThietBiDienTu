namespace Domain.DTO.Comment
{
    public class CommentEditModel
    {
        public string Detail { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}
