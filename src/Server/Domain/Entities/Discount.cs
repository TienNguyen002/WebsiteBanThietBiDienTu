using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //Sản phẩm giảm giá
    public class Discount : IEntity
    {
        //Mã giảm giá
        public int Id { get; set; }

        //Code giảm giá
        public string CodeName { get; set; } = null!;

        //Phần trăm giảm giá
        public double DiscountPercent { get; set; }

        //Ngày bắt đầu
        public DateTime StartDate { get; set; }

        //Ngày kết thúc
        public DateTime EndDate { get; set; }

        //Danh sách đơn hàng
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
