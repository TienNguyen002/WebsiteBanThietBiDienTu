using Domain.DTO.PaymentMethod;
using Domain.DTO.Status;

namespace Domain.DTO.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public StatusDTO Status { get; set; }
        public PaymentMethodDTO PaymentMethod { get; set; }
    }
}
