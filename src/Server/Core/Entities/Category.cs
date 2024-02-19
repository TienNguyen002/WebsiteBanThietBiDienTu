using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Danh mục thiết bị
    public class Category : IEntity
    {
        //Mã danh mục
        public int Id { get; set; }

        //Tên danh mục
        public string Name { get; set; }

        //Tên định danh dùng để tạo URL
        public string UrlSlug { get; set; }

        //Danh sách thương hiệu
        public IList<Trademark> Trademarks { get; set; }
        
        //Danh sách thiết bị
        public IList<Product> Products { get; set; }
    }
}
