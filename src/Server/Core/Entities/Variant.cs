using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Thuộc tính
    public class Variant : IEntity
    {
        //Mã thuộc tính
        public int Id { get; set; }

        //Tên thuộc tính
        public string Name { get; set; }

        //Mã định danh thuộc tính
        public string UrlSlug { get; set; }

        //Số lượng trong kho
        public int Amount { get; set; }

        //Tình trạng
        public bool Status { get; set; }

        //Giá hiện tại
        public int? Price { get; set; }

        //Giá gốc
        public int OrPrice { get; set; }

        //Mã thiết bị
        public int ProductId { get; set; }

        //Thiết bị
        public Product Product { get; set; }

        //Danh sách màu
        public IList<Color> Colors { get; set; }

        //Danh sách thông số kỹ thuật
        public IList<Specification> Specifications { get; set; }

        //Danh sách giỏ hàng
        public IList<Cart> Carts { get; set; }
    }
}
