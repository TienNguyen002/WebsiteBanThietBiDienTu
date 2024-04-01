using Domain.Contracts;

namespace Domain.Entities
{
    //Vai trò
    public class Role : IEntity
    {
        //Mã vai trò
        public int Id { get; set; }

        //Tên vai trò
        public string Name { get; set; } = null!;

        //Mã định danh
        public string UrlSlug { get; set; } = null!;

        //Danh sách người dùng
        public IList<User> Users { get; set; } = new List<User>();
    }
}
