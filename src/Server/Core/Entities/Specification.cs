using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Thông số kỹ thuật
    public class Specification : IEntity
    {
        //Mã thông số
        public int Id { get; set; }

        //Mã danh mục thông số
        public int SpecificationCategoryId { get; set; }

        //Danh mục thông số
        public SpecificationCategory SpecificationCategory { get; set; }

        //Chi tiết thông số
        public string Details { get; set; }

        //Danh sách sản phẩm
        public IList<Variant> Variants { get; set; }
    }
}
