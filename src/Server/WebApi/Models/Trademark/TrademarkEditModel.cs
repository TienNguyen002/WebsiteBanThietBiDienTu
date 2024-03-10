using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.Models.Trademark
{
    public class TrademarkEditModel
    {
        public int Id { get; set; }

        [DisplayName("Tên thương hiệu")]
        [Required(ErrorMessage = "Tên thương hiệu không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Tên thương hiệu tối đa 100 ký tự")]
        public string Name { get; set; }

        [DisplayName("Slug thương hiệu")]
        [Required(ErrorMessage = "Slug thương hiệu không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Slug thương hiệu tối đa 100 ký tự")]
        public string UrlSlug { get; set; }

        public static async ValueTask<TrademarkEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new TrademarkEditModel()
            {
                Id = int.Parse(form["Id"]),
                Name = form["Name"],
                UrlSlug = form["UrlSlug"]
            };
        }
    }
}
