using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Nhập hàng
    public class Storage : IEntity
    {
        //Mã nhập hàng
        public int Id { get; set; } 

        //Mã nhân viên nhập
        public int StaffId { get; set; }

        //Nhân viên
        public Staff Staff { get; set; }

        //Mã sản phẩm 
        public int ProductId { get; set; }

        //Sản phẩm nhập
        public Product Product { get; set; }

        //Số lượng Nhập
        public int Amount { get; set; }
    }
}
