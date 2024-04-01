using Domain.Contracts;

namespace Domain.Entities
{
    //Người dùng
    public class User : IEntity
    {
        //Mã người dùng
        public int Id { get; set; }

        //Tên người dùng
        public string Name { get; set; } = null!;

        //Mã định danh người dùng
        public string UrlSlug { get; set; } = null!;

        //Email người dùng
        public string Email { get; set; } = null!;

        //SDT người dùng
        public string Phone { get; set; } = null!;

        //Mật khẩu
        public string Password { get; set; } = null!;

        //Địa chỉ
        public string Address { get; set; } = null!;

        //Mã vai trò
        public int RoleId { get; set; }

        //Vai trò
        public Role? Role { get; set; }

        //Danh sách comment
        public IList<Comment> Comments { get; set; } = new List<Comment>();

        //Danh sách đơn hàng
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
