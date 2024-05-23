using Domain.DTO.OrderItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Order
{
    public class OrderEditModel
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int StatusId { get; set; }
        public string UserId { get; set; }
        public int PaymentMethodId { get; set; }
        public int DiscountId { get; set; }
        [Required]
        public IList<OrderItemEditModel> OrderItems { get; set; } = new List<OrderItemEditModel>();
    }
}
