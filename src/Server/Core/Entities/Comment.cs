using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Bình luận của người dùng
    public class Comment : IEntity
    {
        //Mã bình luận
        public int Id { get; set; }

        //Mã người bình luận
        public int UserId { get; set; }

        //Người bình luận
        public User User { get; set; }

        //Mã thiết bị bình luận
        public int ProductId { get; set; }

        //Thiết bị
        public Product Product { get; set; }

        //Chi tiết bình luận
        public string Detail { get; set; }

        //Ngày bình luận
        public DateTime CreatedDate { get; set; }
    }
}
