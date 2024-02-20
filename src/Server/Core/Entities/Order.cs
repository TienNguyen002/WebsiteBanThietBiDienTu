using Core.Contracts;
using System;
using System.Collections.Generic;
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

        //Mã giỏ hàng
        public int CartId { get; set; }

        //Ngày đặt hàng
        public DateTime DateOrder { get; set; }

        //Giỏ hàng
        public Cart Cart { get; set; }

        //Mã tình trạng
        public int StatusId { get; set; } 

        //Tình trạng
        public Status Status { get; set; }
    }
}
