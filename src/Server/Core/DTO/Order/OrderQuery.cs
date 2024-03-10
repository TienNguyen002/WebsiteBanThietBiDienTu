using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Order
{
    public class OrderQuery
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? StatusId { get; set; }
    }
}
