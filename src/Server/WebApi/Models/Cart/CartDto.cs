using WebApi.Models.Customer;
using WebApi.Models.Product;

namespace WebApi.Models.Cart
{
    public class CartDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public IList<ProductDto> Products { get; set; }
        public bool Status { get; set; }
    }
}
