using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.Models.Order
{
    public class OrderEditModel
    {
        public int Id { get; set; }

        [DisplayName("Tên khách hàng")]
        [Required(ErrorMessage = "Tên khách hàng không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Tên khách hàng tối đa 100 ký tự")]
        public string CustomerName { get; set; }

        [DisplayName("Email khách hàng")]
        [Required(ErrorMessage = "Email khách hàng không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Email khách hàng tối đa 100 ký tự")]
        public string Email { get; set; }

        [DisplayName("SĐT khách hàng")]
        [Required(ErrorMessage = "SĐT khách hàng không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "SĐT khách hàng tối đa 100 ký tự")]
        public string Phone { get; set; }

        [DisplayName("Địa chỉ khách hàng")]
        [Required(ErrorMessage = "Địa chỉ khách hàng không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Địa chỉ khách hàng tối đa 100 ký tự")]
        public string Address { get; set; }

        [DisplayName("Mã giỏ hàng")]
        [Required(ErrorMessage = "Mã giỏ hàng không được bỏ trống")]
        public int CartId { get; set; }

        public static async ValueTask<OrderEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new OrderEditModel()
            {
                Id = int.Parse(form["Id"]),
                CustomerName = form["CustomerName"],
                Email = form["Email"],
                Phone = form["Phone"],
                Address = form["Address"],
                CartId = int.Parse(form["CartId"])
            };
        }
    }
}
