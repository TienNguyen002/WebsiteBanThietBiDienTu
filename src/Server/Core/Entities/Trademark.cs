using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Thương hiệu
    public class Trademark : IEntity
    {
        //Mã thương hiệu
        public int Id { get; set; }

        //Tên thương hiệu
        public string Name { get; set; }

        //Mã định danh
        public string UrlSlug { get; set; }

        //Danh sách Mã danh mục
        public IList<Category> Categories { get; set; }

        //Danh sách sản phẩm
        public IList <Product> Products { get; set; }
    }
}
