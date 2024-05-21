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

        //Hình ảnh của sản phẩm
        public string? ImageUrl { get; set; }

        //Mô tả ngắm
        public string ShortDescription { get; set; } = null!;

        //Thông số kỹ thuật
        public string Specification { get; set; } = null!;

        //Số lượng trong kho
        public int Amount { get; set; }

        //Giá sale
        public int SalePrice { get; set; }

        //Giá hiện tại
        public int Price { get; set; }

        //Giá gốc
        public int OrPrice { get; set; }

        //Số lượng bán
        public int SoldQuantity { get; set; }

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
