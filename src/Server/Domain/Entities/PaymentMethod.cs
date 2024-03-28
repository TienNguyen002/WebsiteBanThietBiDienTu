using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //Phương thức thanh toán
    public class PaymentMethod : IEntity
    {
        //Mã phương thức
        public int Id { get; set; }

        //Loại phương thức
        public string Name { get; set; } = null!;

        //Mô tả
        public string Description { get; set; } = null!;

        //Mã đơn hàng
        public int OrderId { get; set; }

        //Đơn hàng
        public Order? Order { get; set; }
    }
}
