using WebApi.Models.Cart;
using WebApi.Models.Status;

namespace WebApi.Models.Order
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime DateOrder { get; set; }

        public CartDto Cart { get; set; }

        public int Quantity { get; set; }

        public int TotalPrice { get; set; }

        //Tình trạng
        public StatusDto Status { get; set; }
    }
}
