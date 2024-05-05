using Domain.Contracts;

namespace Domain.Entities
{
    //Thương hiệu
    public class Branch : IEntity
    {
        //Mã thương hiệu
        public int Id { get; set; }

        //Tên thương hiệu
        public string Name { get; set; } = null!;

        //Mã định danh
        public string UrlSlug { get; set; } = null!;

        //Hình ảnh
        public string? ImageUrl { get; set; }

        //Danh sách dòng sản phẩm
        public IList<Serie> Series { get; set; } = new List<Serie>();
    }
}
