using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Màu sản phẩm
    public class ProductColor : IEntity
    {
        //Mã màu sản phẩm
        public int Id { get; set; }

        //Màu sản phẩm
        public string Color { get; set; }

        //Mã định danh
        public string UrlSlug { get; set; }

        //Giá hiện tại
        public int? Price { get; set; }

        //Giá gốc
        public int OrPrice { get; set; }

        //Mã cấu hình
        public int ProductId { get; set; }

        //Cấu hình
        public Product Product { get; set; }
    }
}
