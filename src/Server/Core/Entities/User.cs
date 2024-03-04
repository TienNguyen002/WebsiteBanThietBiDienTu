using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Người dùng
    public class User : IEntity
    {
        //Mã người dùng
        public int Id { get; set; }

        //Tên người dùng
        public string Name { get; set; }

        //Mã định danh người dùng
        public string UrlSlug { get; set; }

        //Email người dùng
        public string Email { get; set; }

        //SDT người dùng
        public string Phone { get; set; }   

        //Mật khẩu
        public string Password { get; set; }

        //Địa chỉ
        public string Address { get; set; }

        //Danh sách bình luận
        public IList<Comment> Comments { get; set; }

        //Danh sách giỏ hàng
        public IList<Cart> Carts { get; set; }

        //Danh sách đơn hàng
        public IList<Order> Orders { get; set; }

        //Mã vai trò
        public int? RoleId { get; set; }
        
        //Vai trò
        public Role Role { get; set; }
    }
}
