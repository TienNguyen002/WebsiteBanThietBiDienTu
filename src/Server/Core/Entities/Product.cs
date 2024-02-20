using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Sản phẩm
    public class Product : IEntity
    {
        //Mã sản phẩm
        public int Id { get; set; }

        //Tên sản phẩm
        public string Name { get; set; }

        //Mã định danh
        public string UrlSlug { get; set; }

        //Mô tả
        public string Description { get; set; }

        //Tag
        public string Tag { get; set; }

        //Số lượng trong kho
        public int Amount { get; set; }

        //Tình trạng
        public bool Status { get; set; }

        //Giá hiện tại
        public int? Price { get; set; }

        //Giá gốc
        public int OrPrice { get; set; }

        //Mã danh mục
        public int CategoryId { get; set; }

        //Danh mục
        public Category Category { get; set; }

        //Danh sách cấu hình
        public IList<Configuration> Configurations { get; set; }

        //Danh sách Ảnh
        public IList<Image> Images { get; set; }

        //Mã thương hiệu
        public int TrademarkId { get; set; }

        //Thương hiệu
        public Trademark Trademark { get; set; }

        //Danh sách bình luận
        public IList<Comment> Comments { get; set; }

        //Danh sách thông số kỹ thuật
        public IList<Specification> Specifications { get; set; }

        //Mã nhân viên thêm hàng
        public int StaffId { get; set; }

        //Nhân viên thêm hàng
        public Staff Staff { get; set; }

        //Số lượng thêm
        public int AddAmount { get; set; }
    }
}
