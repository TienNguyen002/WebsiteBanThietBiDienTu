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

        //Mã người dùng thêm vào giỏ hàng
        public int CustomerId { get; set; }

        //Giỏ hàng của người dùng
        public Customer Customer { get; set; }

        //Mã đơn hàng
        public int? OrderId { get; set; }

        //Đơn hàng
        public Order? Order { get; set; }

        //Danh sách sản phẩm
        public IList<Product> Products { get; set; }

        //Tổng giá
        public int TotalPrice { get; set; }

        //Tình trạng giỏ hàng
        public bool Status { get; set; }
    }
}
