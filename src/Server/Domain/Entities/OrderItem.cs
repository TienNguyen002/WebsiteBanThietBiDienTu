using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //Sản phẩm giỏ hàng
    public class OrderItem : IEntity
    {
        //Mã sản phẩm
        public int Id { get; set; }

        //Mã đơn hàng
        public int OrderId { get; set; }   

        //Đơn hàng
        public Order? Order { get; set; }

        //Mã sản phẩm
        public int ProductId { get; set; }

        //Sản phẩm
        public Product? Product { get; set; }

        //Số lượng
        public int Quantity { get; set; }

        //Giá
        public decimal Price { get; set; }
    }
}
