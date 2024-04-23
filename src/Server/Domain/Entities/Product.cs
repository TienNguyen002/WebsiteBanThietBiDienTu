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

        //Tên hiển thị
        public string ShortName { get; set; } = null!;

        //Mã định danh sản phẩm
        public string UrlSlug { get; set; } = null!;

        //Tổng đánh giá
        public decimal Rating { get; set; }

        //Hình ảnh của sản phẩm
        public string? ImageUrl { get; set; }

        //Mô tả ngắm
        public string ShortDescription { get; set; } = null!;

        //Thông số kỹ thuật
        public string Specification { get; set; } = null!;

        //Số lượng trong kho
        public int Amount { get; set; }

        //Giá sale
        public decimal SalePrice { get; set; }

        //Giá hiện tại
        public decimal Price { get; set; }

        //Giá gốc
        public decimal OrPrice { get; set; }

        //Số lượng bán
        public int SoldQuantity { get; set; }

        //Mã danh mục
        public int CategoryId { get; set; }
        
        //Danh mục
        public Category? Category { get; set; }

        //Mã thương hiệu
        public int BranchId { get; set; }

        //Thương hiệu
        public Branch? Branch { get; set; }

        //Mã đòng
        public int SerieId { get; set; }

        //Dòng sản phẩm
        public Serie? Serie { get; set; }

        //Mã sale
        public int SaleId { get; set; }

        //Sale
        public Sale? Sale { get; set; }

        //Danh sách màu
        public IList<Color> Colors { get; set; } = new List<Color>();

        //Danh sách sản phẩm đơn hàng
        public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
