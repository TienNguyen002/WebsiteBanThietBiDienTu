using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Cấu hình sản phẩm
    public class Configuration : IEntity
    {
        //Mã cấu hình
        public int Id { get; set; }

        //Tên cấu hình
        public string Name { get; set; }

        //Mã định danh
        public string UrlSlug { get; set; }

        //Giá sản phẩm
        public int Price { get; set; }

        //Mã sản phẩm
        public int ProductId { get; set; }

        //Sản phẩm
        public Product Product { get; set; }

        //Danh sách màu sản phẩm
        public IList<ProductColor> Colors { get; set; }
    }
}
