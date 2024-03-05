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

        //Mã định danh sản phẩm
        public string UrlSlug { get; set; }

        //Hình ảnh của sản phẩm
        public string ImageUrl { get; set; }

        //Mô tả
        public string Description { get; set; }

        //Mã tag
        public int TagId { get; set; }

        //Tag
        public Tag Tag { get; set; }

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

        //Mã thương hiệu
        public int TrademarkId { get; set; }

        //Thương hiệu
        public Trademark Trademark { get; set; }

        //Danh sách ảnh
        public IList<Image> Images { get; set; }

        //Danh sách bình luận
        public IList<Comment> Comments { get; set; }

        //Danh sách màu
        public IList<Color> Colors { get; set; }

        //Danh sách thông số kỹ thuật
        public IList<Specification> Specifications { get; set; }

        //Danh sách giỏ hàng
        public IList<Cart> Carts { get; set; }
    }
}
