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

        //Danh sách đơn hàng
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
