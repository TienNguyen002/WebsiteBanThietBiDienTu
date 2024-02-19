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

        //Mã người đặt
        public int CustomerId { get; set; }

        //Mã giỏ hàng
        public int CartId { get; set; }

        //Ngày đặt hàng
        public DateTime DateOrder { get; set; }

        //Người đặt
        public Customer Customer { get; set; }

        //Giỏ hàng
        public Cart Cart { get; set; }
    }
}
