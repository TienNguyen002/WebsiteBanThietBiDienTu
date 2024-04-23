using Domain.Contracts;

namespace Domain.Entities
{
    //Sale
    public class Sale : IEntity
    {
        //Sale Id
        public int Id { get; set; }
        
        //Ngày kết thúc sale
        public DateTime EndDate { get; set; }

        //Trạng thái
        public bool Status { get; set; }

        //Danh sách sản phẩm giảm giá
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
