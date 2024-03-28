using Domain.Contracts;

namespace Domain.Entities
{
    //Tình trạng đơn hàng
    public class Status : IEntity
    {
        //Mã tình trạng
        public int Id { get; set; }

        //Tên tình trạng
        public string Name { get; set; } = null!;

        //Mã định danh tình trạng
        public string UrlSlug { get; set; } = null!;

        //Danh sách đơn hàng
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
