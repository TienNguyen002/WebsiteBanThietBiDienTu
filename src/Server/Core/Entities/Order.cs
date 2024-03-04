using Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Đơn hàng
    public class Order : IEntity
    {
        //Mã đơn hàng
        public int Id { get; set; }

        //Họ tên người đặt
        public string CustomerName { get; set; }

        //Địa chỉ
        public string Address { get; set; }

        //SĐT
        public string Phone { get; set; }

        //Email
        public string Email { get; set; }

        //Ngày đặt hàng
        public DateTime DateOrder { get; set; }

        //Mã giỏ hàng
        public int CartId { get; set; }

        //Giỏ hàng
        public Cart Cart { get; set; }

        //Tổng số lượng sản phẩm
        public int Quantity { get; set; }

        //Tổng tiền
        public int TotalPrice { get; set; }

        //Mã tình trạng
        public int StatusId { get; set; } 

        //Tình trạng
        public Status Status { get; set; }
    }
}
