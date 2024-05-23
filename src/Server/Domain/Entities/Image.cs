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

        //Mã dòng sản phẩm
        public int SerieId { get; set; }

        //Dòng sản phẩm
        public Serie? Serie { get; set; }
    }
}
