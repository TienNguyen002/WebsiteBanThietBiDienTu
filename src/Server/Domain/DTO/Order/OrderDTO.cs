using Domain.DTO.PaymentMethod;
using Domain.DTO.Status;

namespace Domain.DTO.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime DateOrder { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
    }
}
