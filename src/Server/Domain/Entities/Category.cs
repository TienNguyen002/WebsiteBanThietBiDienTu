using Domain.Contracts;

namespace Domain.Entities
{
    //Danh mục thiết bị
    public class Category : IEntity
    {
        //Mã danh mục
        public int Id { get; set; }

        //Tên danh mục
        public string Name { get; set; } = null!;

        //Mã định danh
        public string UrlSlug { get; set; } = null!;

        //Danh sách sản phẩm
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
