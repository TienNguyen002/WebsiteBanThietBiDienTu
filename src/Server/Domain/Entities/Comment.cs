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
        public float Rating { get; set; }

        //Ngày bình luận
        public DateTime CommentDate { get; set; }

        //Trạng thái
        public bool Status { get; set; }

        //Mã dòng
        public int SerieId { get; set; }

        //Dòng sản phẩm
        public Serie? Serie { get; set; }

        //Mã người dùng
        public string? ApplicationUserId { get; set; }

        //Người dùng
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
