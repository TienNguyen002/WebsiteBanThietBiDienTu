using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Khách hàng
    public class Customer : IEntity
    {
        //Mã khách hàng
        public int Id { get; set; }

        //Tên khách hàng
        public string Name { get; set; }

        //Mã định danh khách hàng
        public string UrlSlug { get; set; }

        //Email khách hàng
        public string Email { get; set; }

        //SDT khách hàng
        public string Phone { get; set; }   

        //Mật khẩu
        public string Password { get; set; }

        //Danh sách bình luận
        public IList<Comment> Comments { get; set; }
    }
}
