using Domain.Contracts;

namespace Domain.Entities
{
    //Màu sản phẩm
    public class Color : IEntity
    {
        //Mã màu
        public int Id { get; set; }

        //Tên màu
        public string Name { get; set; } = null!;

        //Mã định danh
        public string UrlSlug { get; set; } = null!;

        //Danh sách sản phẩm
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
