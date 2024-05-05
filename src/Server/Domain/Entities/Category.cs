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

        //Hình ảnh
        public string? ImageUrl { get; set; }

        //Danh sách dòng sản phẩm
        public IList<Serie> Series { get; set; } = new List<Serie>();
    }
}
