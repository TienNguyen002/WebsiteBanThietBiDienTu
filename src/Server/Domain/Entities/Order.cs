using Domain.Contracts;

namespace Domain.Entities
{
    //Đơn hàng
    public class Order : IEntity
    {
        //Mã đơn hàng
        public int Id { get; set; }

        //Mã định dạng đơn hàng
        public string Name { get; set; }

        //Ngày đặt hàng
        public DateTime DateOrder { get; set; }

        //Tổng số lượng sản phẩm
        public int Quantity { get; set; }

        //Tổng tiền
        public int TotalPrice { get; set; }

        //Mã trạng thái
        public int StatusId { get; set; }

        //Trạng thái 
        public Status? Status { get; set; }

        //Mã người dùng
        public int UserId { get; set; }

        //Người dùng
        public User? User { get; set; }

        //Mã phương thức
        public int PaymentMethodId { get; set; }

        //Phương thức
        public PaymentMethod? PaymentMethod { get; set; }

        //Mã giảm giá
        public int DiscountId { get; set; }

        //Giảm giá
        public Discount? Discount { get; set; }

        //Danh sách sản phẩm
        public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
