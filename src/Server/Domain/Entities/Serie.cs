using Domain.Contracts;

namespace Domain.Entities
{
    //Dòng sản phẩm
    public class Serie : IEntity
    {
        //Mã dòng sản phẩm
        public int Id { get; set; }

        //Tên dòng
        public string Name { get; set; } = null!;

        //Mã định danh
        public string UrlSlug { get; set; } = null!;

        //Mô tả
        public string Description { get; set; } = null!;

        //Danh sách bình luận
        public IList<Comment> Comments { get; set; } = new List<Comment>();

        //Danh sách sản phẩm
        public IList<Product> Products { get; set; } = new List<Product>();

        //Danh sách hình ảnh
        public IList<Image> Images { get; set; } = new List<Image>();
    }
}
