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

        //Giá
        public int Price { get; set; }

        //Mã cấu hình
        public int ConfigurationId { get; set; }

        //Cấu hình
        public Configuration Configuration { get; set; }
    }
}
