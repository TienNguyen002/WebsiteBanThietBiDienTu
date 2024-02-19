using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Hình ảnh sản phẩm
    public class Image : IEntity
    {
        //Mã hình ảnh
        public int Id { get; set; } 

        //Đường dẫn tập tin hình ảnh
        public string ImageUrl { get; set; }

        //Mã sản phẩm
        public int ProductId { get; set; }

        //Sản phẩm
        public Product Product { get; set; }
    }
}
