using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.OrderItem
{
    public class OrderItemsDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
