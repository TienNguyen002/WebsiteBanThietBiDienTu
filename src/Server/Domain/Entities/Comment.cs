using Domain.Contracts;

namespace Domain.Entities
{
    //Bình luận của người dùng
    public class Comment : IEntity
    {
        //Mã bình luận
        public int Id { get; set; }

        //Chi tiết bình luận
        public string Detail { get; set; } = null!;

        //Đánh giá
        public int Rating { get; set; }

        //Ngày bình luận
        public DateTime CommentDate { get; set; }

        //Mã sản phẩm
        public int ProductId { get; set; }

        //Sản phẩm
        public Product? Product { get; set; }

        //Mã người dùng
        public int UserId { get; set; }

        //Người dùng
        public User? User { get; set; }
    }
}
