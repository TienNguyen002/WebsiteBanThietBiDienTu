using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Product
{
    public class ProductQuery
    {
        public string Keyword { get; set; }
        public string CategorySlug { get; set; }
        public string TrademarkSlug { get; set; }
        public string Tag { get; set; }
    }
}
