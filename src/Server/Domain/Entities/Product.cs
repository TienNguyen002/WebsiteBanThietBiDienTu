using Domain.Contracts;

namespace Domain.Entities
{
    //Sản phẩm
    public class Product : IEntity
    {
        //Mã sản phẩm
        public int Id { get; set; }

        //Tên sản phẩm
        public string Name { get; set; } = null!;

        //Mã định danh sản phẩm
        public string UrlSlug { get; set; } = null!;

        //Hình ảnh của sản phẩm
        public string? ImageUrl { get; set; }

        //Mô tả
        public string Description { get; set; } = null!;

        //Thông số kỹ thuật
        public string Specification { get; set; } = null!;

        //Số lượng trong kho
        public int Amount { get; set; }

        //Tình trạng
        public bool Status { get; set; }

        //Giá hiện tại
        public decimal Price { get; set; }

        //Giá gốc
        public decimal OrPrice { get; set; }

        //Mã danh mục
        public int CategoryId { get; set; }
        
        //Danh mục
        public Category? Category { get; set; }

        //Mã thương hiệu
        public int BranchId { get; set; }

        //Thương hiệu
        public Branch? Branch { get; set; }

        //Mã Tag
        public int TagId { get; set; }

        //Tag
        public Tag? Tag { get; set; }

        //Danh sách hình ảnh
        public IList<Image> Images { get; set; } = new List<Image>();

        //Danh sách màu
        public IList<Color> Colors { get; set; } = new List<Color>();

        //Danh sách comment
        public IList<Comment> Comments { get; set; } = new List<Comment>();

        //Danh sách giảm giá
        public IList<Discount> Discounts { get; set; } = new List<Discount>();

        //Danh sách sản phẩm đơn hàng
        public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
