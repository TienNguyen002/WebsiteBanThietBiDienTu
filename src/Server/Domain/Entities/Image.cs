using Domain.Contracts;

namespace Domain.Entities
{
    //Hình ảnh sản phẩm
    public class Image : IEntity
    {
        //Mã hình ảnh
        public int Id { get; set; }

        //Đường dẫn tập tin hình ảnh
        public string ImageUrl { get; set; } = null!;

        //Mã sản phẩm
        public int ProductId { get; set; }

        //Sản phẩm
        public Product? Product { get; set; }
    }
}
