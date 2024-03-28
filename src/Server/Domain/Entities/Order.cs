using Domain.Contracts;

namespace Domain.Entities
{
    //Đơn hàng
    public class Order : IEntity
    {
        //Mã đơn hàng
        public int Id { get; set; }

        //Ngày đặt hàng
        public DateTime DateOrder { get; set; }

        //Tổng số lượng sản phẩm
        public int Quantity { get; set; }

        //Tổng tiền
        public decimal TotalPrice { get; set; }

        //Mã trạng thái
        public int StatusId { get; set; }

        //Trạng thái 
        public Status? Status { get; set; }

        //Mã người dùng
        public int UserId { get; set; }

        //Người dùng
        public User? User { get; set; }

        //Danh sách sản phẩm
        public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        //Danh sách phương thức
        public IList<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    }
}
