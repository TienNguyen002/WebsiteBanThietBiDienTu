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

        //Giá giảm giá
        public decimal DiscountPrice { get; set; }

        //Ngày bắt đầu
        public DateTime StartDate { get; set; }

        //Ngày kết thúc
        public DateTime EndDate { get; set; }

        //Trạng thái
        public bool Status { get; set; }

        //Mã sản phẩm
        public int ProductId { get; set; }

        //Sản phẩm
        public Product? Product { get; set; }
    }
}
