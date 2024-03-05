using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebApi.Models.Category;

namespace WebApi.Models.Comment
{
    public class CommentEditModel
    {
        public int Id { get; set; }

        [DisplayName("Nội dung")]
        [Required(ErrorMessage = "Nội dung không được bỏ trống")]
        [MaxLength(500, ErrorMessage = "Nội dung tối đa 500 ký tự")]
        public string Detail { get; set; }

        [DisplayName("Khách hàng")]
        [Required]
        public int CustomerId { get; set; }

        [DisplayName("Sản phẩm")]
        [Required]
        public int ProductId { get; set; }

        [DisplayName("Ngày bình luận")]
        [Required]
        public DateTime CreatedDate { get; set; }

        public static async ValueTask<CommentEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new CommentEditModel()
            {
                Id = int.Parse(form["Id"]),
                Detail = form["Detail"],
                CustomerId = int.Parse(form["Id"]),
                ProductId = int.Parse(form["Id"]),
                CreatedDate = DateTime.Parse(form["CreatedDate"]),
            };
        }
    }
}
