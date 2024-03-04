using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Vai trò
    public class Role : IEntity
    {
        //Mã vai trò
        public int Id { get; set; }

        //Tên vai trò
        public string Name { get; set; }

        //UrlSlug vai trò
        public string UrlSlug { get; set; }

        //Danh sách người dùng
        public IList<User> Users { get; set; }
    }
}
