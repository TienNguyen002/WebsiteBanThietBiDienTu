using Domain.Contracts;

namespace Domain.Entities
{
    //Tag sản phẩm
    public class Tag : IEntity
    {
        //Mã tag
        public int Id { get; set; }

        //Tên tag
        public string Name { get; set; } = null!;

        //Mã định danh Tag
        public string UrlSlug { get; set; } = null!;

        //Danh sách sản phẩm
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
