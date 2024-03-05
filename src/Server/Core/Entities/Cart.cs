using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Giỏ hàng
    public class Cart : IEntity
    {
        //Mã giỏ hàng
        public int Id { get; set; }

        //Mã người dùng
        public int UserId { get; set; }

        //Người dùng
        public User User { get; set; }

        //Danh sách đơn hàng
        public IList<Order> Orders { get; set; }

        //Danh sách sản phẩm
        public IList<Product> Products { get; set; }

        //Tình trạng giỏ hàng
        public bool Status { get; set; }
    }
}
