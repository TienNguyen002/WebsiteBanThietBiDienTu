using Domain.Contracts;

namespace Domain.Entities
{
    //Sản phẩm giỏ hàng
    public class OrderItem : IEntity
    {
        //Mã sản phẩm
        public int Id { get; set; }

        //Số lượng
        public int Quantity { get; set; }

        //Giá
        public int Price { get; set; }

        //Mã đơn hàng
        public int OrderId { get; set; }

        //Đơn hàng
        public Order? Order { get; set; }

        //Mã sản phẩm
        public int ProductId { get; set; }

        //Sản phẩm
        public Product? Product { get; set; }
    }
}
