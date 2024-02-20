using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Danh mục thông số
    public class SpecificationCategory : IEntity
    {
        //Mã danh mục
        public int Id { get; set; }

        //Tên danh mục
        public string Name { get; set; }

        //Mã định danh
        public string UrlSlug { get; set; }

        //Danh sách thông số
        public IList<Specification> Specifications { get; set; }
    }
}
