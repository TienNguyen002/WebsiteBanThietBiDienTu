namespace Domain.DTO.Comment
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Detail { get; set; } = null!;
        public int Rating { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
