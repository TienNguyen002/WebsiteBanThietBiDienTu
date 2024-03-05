using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Tag sản phẩm
    public class Tag : IEntity
    {
        //Mã tag
        public int Id { get; set; }

        //Tên tag
        public string Name { get; set; }  

        //Mã định danh Tag
        public string UrlSlug { get; set; }

        //Danh sách sản phẩm
        public IList<Product> Products { get; set; }
    }
}
